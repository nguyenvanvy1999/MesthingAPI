using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace MesthingAPI.Models
{
    public class AdminModel
    {
        [Key]
        [Required]
        [DisplayName("AdminID")]
        public int AdminID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Admin Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Admin password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 4)]
        public string Password { get; set; }

    }
}
