﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.MedicalCenter
{
    internal interface IMedicalCenterDto
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
