using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.DTOs
{
    public class TokenDto
    {
        public string AccessToken {  get; set; }
        public string RefreshToken { get; set; }
    }
}
