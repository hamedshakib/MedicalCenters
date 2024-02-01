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
    }
}
