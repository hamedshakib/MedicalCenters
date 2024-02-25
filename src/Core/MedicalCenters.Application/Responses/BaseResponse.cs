using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Responses
{
    public class BaseResponse
    {
        public bool IsSusses { get; set; } = false;
        public IList<ErrorResponse>? Errors { get; set; }
    }
}
