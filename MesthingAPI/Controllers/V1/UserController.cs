using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MesthingAPI.Data;
using MesthingAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;


namespace MesthingAPI.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/user")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
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
        public ActionResult<string> SignIn([FromForm] string email, [FromForm] string password)
        {
            var User = (from x in _db.Users
                        where x.Email == email
                        select x).FirstOrDefault();
            if (User == null) return BadRequest("Email wrong !");
            if (User.Password != password) return BadRequest("Email wrong !");
            return Ok("Sign in successfully !");
        }
        [HttpPost]
        public JsonResult CreateNewUser([FromForm] UserModel user)
        {
            var newUser = new UserModel
            {
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DoB = user.DoB,
                Address = user.Address,
                Phone = user.Phone
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
