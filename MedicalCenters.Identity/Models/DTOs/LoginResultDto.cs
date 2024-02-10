using MedicalCenters.Identity.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.DTOs
{
    public class LoginResultDto
    {
        public bool IsFindUser { get; set; } = false;
        public LoginUserModel LoginUser { get; set; }

    }
}
