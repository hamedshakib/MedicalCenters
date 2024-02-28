using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Identity.Models.DTOs
{
    public class LoginDto
    {
        [Required, StringLength(100)]
        public string Username { get; set; }
        [Required, StringLength(100)]
        public string Password { get; set; }
    }
}
