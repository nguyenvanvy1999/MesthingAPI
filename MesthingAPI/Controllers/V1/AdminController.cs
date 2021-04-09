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
using Microsoft.AspNetCore.Identity;

namespace MesthingAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        #region Get
        [HttpGet]
        public async Task<ActionResult<AdminModel[]>> GetAllAdmin() => new JsonResult(await _db.Admins.ToListAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminModel>> GetAdminByID([FromBody] int id) => new JsonResult(await _db.Admins.FindAsync(id));
        [HttpGet("email")]
        public async Task<ActionResult<AdminModel>> GetAdminByEmail([FromBody] string email) => new JsonResult(await _db.Admins.FirstOrDefaultAsync(x => x.Email == email));
        #endregion
    }
}
