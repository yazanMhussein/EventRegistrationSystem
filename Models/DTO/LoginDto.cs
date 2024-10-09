using System.ComponentModel.DataAnnotations;

namespace Event_Registration_System.Models.DTO
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
