using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesthingAPI.Models.Requests
{
    public class UserRegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public string Phone { get; set; }
    }
}
