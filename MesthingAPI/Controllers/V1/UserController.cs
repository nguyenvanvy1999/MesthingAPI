using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MesthingAPI.Data;
using MesthingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using MesthingAPI.Tools;
using BC = BCrypt.Net.BCrypt;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MesthingAPI.Models.Requests;

namespace MesthingAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/user")]
    public class UserController : Controller
    {
        #region Configure
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        public UserController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        #endregion
        #region Get
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUserByID(int id) => new JsonResult(await _db.Users.FindAsync(id));
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUser() => new JsonResult(await _db.Users.ToListAsync());
        [HttpGet("search/{email}")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUserByEmail(string email) => new JsonResult(await _db.Users.FirstOrDefaultAsync(x => x.Email == email));

        #endregion
        #region Put
        [HttpPut("password")]
        public async Task<ActionResult<IEnumerable<UserModel>>> EditUserPassword([FromForm] string password, [FromForm] string repeatPassword)
        {
            if (password != repeatPassword) return BadRequest("Repear password wrong !");
            return new JsonResult(await _db.Users.FindAsync());
        }
        [HttpPut]
        [ValidateAntiForgeryToken]
        public JsonResult Edit()
        {
            return new JsonResult("Edit user !");
        }
        #endregion
        #region Post
        [HttpPost("signin")]
        public async Task<ActionResult<string>> SignIn([FromForm] UserLoginRequest form)
        {
            var user = await (from x in _db.Users
                              where x.Email == form.Email
                              select x).FirstOrDefaultAsync();
            if (user == null) return BadRequest("Email wrong !");
            if (!BC.Verify(form.Password, user.Password)) return BadRequest("Password wrong !");
            var token = JWTTool.GeneraToken(user);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> CreateNewUser([FromForm] UserRegisterRequest user, [FromForm] int AdminID)
        {
            var isUser = await (from x in _db.Users
                                where x.Email == user.Email
                                select x).FirstOrDefaultAsync();
            if (isUser != null) return BadRequest("Email has been exits");
            var newUser = new UserModel
            {
                Email = user.Email,
                Password = BC.HashPassword(user.Password),
                FirstName = user.FirstName,
                LastName = user.LastName,
                DoB = user.DoB,
                Address = user.Address,
                Phone = user.Phone,
                CreateAt = DateTime.Now,
                EditBy = AdminID,
            };
            _db.Add(newUser);
            _db.SaveChanges();
            return new JsonResult("Create Successfully !");
        }
        #endregion
        #region Delete
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public JsonResult Delete()
        {
            return new JsonResult("Delete user !");
        }
        #endregion
    }
}
