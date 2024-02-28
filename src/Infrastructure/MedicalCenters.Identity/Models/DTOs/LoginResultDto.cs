namespace MedicalCenters.Identity.Models.DTOs
{
    public class LoginResultDto
    {
        public bool IsFindUser { get; set; } = false;
        public LoginUserModel LoginUser { get; set; }

    }
}
