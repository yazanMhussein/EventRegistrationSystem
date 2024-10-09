using System.ComponentModel.DataAnnotations;

namespace Event_Registration_System.Models.DTO
{
    public class RegisterUserDto
    {

        [Required]
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
