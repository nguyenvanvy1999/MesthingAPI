using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MesthingAPI.Models.Auths
{
    public class RefreshToken
    {
        public int ID { get; set; }
        public string UserID { get; set; } // Linked to the AspNet Identity User Id
        public string Token { get; set; }
        public string JwtID { get; set; } // Map the token with jwtId
        public bool IsUsed { get; set; } // if its used we dont want generate a new Jwt token with the same refresh token
        public bool IsRevoked { get; set; } // if it has been revoke for security reasons
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; } // Refresh token is long lived it could last for months.

        [ForeignKey(nameof(UserID))]
        public IdentityUser User { get; set; }
    }
}
