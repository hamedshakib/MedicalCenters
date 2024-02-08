using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.MedicalCenter
{
    public class MedicalCenterDto : BaseDto,IMedicalCenterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public double GPSx { get; set; }
        public double GPSy { get; set; }
    }
}
