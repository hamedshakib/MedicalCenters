using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Contracts.Error
{
    public enum ErrorEnums
    {
        UnKnown = -1,
        Validation = 1,
        NotFound = 2,
        ConvertData = 3,
        Query = 4,
    }
}
