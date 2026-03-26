using System.ComponentModel.DataAnnotations;

namespace AIScheduleUI5.Models
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
