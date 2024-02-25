using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Responses
{
    public record ErrorResponse(int ErrorCode,string ErrorMessage){}
}
