using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MesthingAPI.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        [DisplayName("UserID")]
        public int UserID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [DisplayName("DOB")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [DisplayName("Create At")]
        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
        [DisplayName("Update At")]
        [DataType(DataType.Date)]
        public DateTime UpdateAt { get; set; }
        [DisplayName("Delete At")]
        [DataType(DataType.Date)]
        public DateTime DeleteAt { get; set; }
        [Required]
        [DisplayName("Edit By")]
        public int EditBy { get; set; }
        [Required]
        [DisplayName("Devices of user")]
        public List<DeviceModel> Devices { get; set; }
    }
}
