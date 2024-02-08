﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string NotFoundObject)
        {
            NotFound_Object = NotFoundObject;
        }
        public string NotFound_Object;
    }
}
