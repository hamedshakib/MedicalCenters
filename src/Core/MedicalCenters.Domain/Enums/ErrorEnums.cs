﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Enums
{
    public enum ErrorEnums
    {
        UnKnown = -1,
        Validation = 1,
        NotFound = 2,
        ConvertData = 3,
        Query = 4,
        LoginFailed = 5,
        UnAuthroze = 6,
        TaskCanceled = 7,
    }
}