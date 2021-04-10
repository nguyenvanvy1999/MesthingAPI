using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MesthingAPI.Models
{
    public class DeviceModel
    {
        [Key]
        [Required]
        [DisplayName("DeviceID")]
        public int DeviceID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("DeviceName")]
        public string DeviceName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("DeviceType")]
        public string DeviveType { get; set; }
        [Required]
        [DisplayName("User of device")]
        public UserModel IsActive { get; set; }
    }
}
