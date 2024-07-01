using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Identity.Models.DTOs
{
    public class LoginDto
    {
        [Required, MaxLength(100)]
        public string Username { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
    }
}
