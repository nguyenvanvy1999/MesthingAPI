using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesthingAPI.Models.Auths
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public DateTime ExpiryTimeFrame { get; set; }
        public string RefreshToken { get; set; }
        public List<string> Errors { get; set; }
    }
}
