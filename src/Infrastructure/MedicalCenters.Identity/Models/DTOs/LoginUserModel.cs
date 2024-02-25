using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.DTOs
{
    public record LoginUserModel(long UserId, string UserName)
    {

    }
}
