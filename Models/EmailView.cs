using System.ComponentModel.DataAnnotations;

namespace Event_Registration_System.Models
{
    public class EmailView
    {
        [Required(ErrorMessage = "Email is required")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ToName { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string TextPart { get; set; }
    }
}
