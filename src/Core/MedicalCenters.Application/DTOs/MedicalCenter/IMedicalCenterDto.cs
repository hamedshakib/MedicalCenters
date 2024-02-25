using System;
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
        public int TypeId { get; set; }
        public string Address { get; set; }
        public double GPSx { get; set; }
        public double GPSy { get; set; }
    }
}
