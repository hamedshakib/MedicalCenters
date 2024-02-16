﻿using MedicalCenters.Domain.Entities;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.MedicalCenter
{
    public class CreateMedicalCenterDto : IMedicalCenterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string Address { get; set; }
        public double GPSx { get; set; }
        public double GPSy { get; set; }

    }
}
