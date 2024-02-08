using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.MedicalWard
{
    internal class CreateMedicalWardDto : IMedicalWardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}
