using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.MedicalCenter
{
    public class CreateMedicalCenterDto : IMedicalCenterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
