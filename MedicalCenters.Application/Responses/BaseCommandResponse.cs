using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Responses
{
    public class BaseCommandResponse
    {
        public bool IsSusses {  get; set; } = false;
        public long? Id { get; set; }
        public IList<ErrorResponse>? Errors {get; set;}
    }
}
