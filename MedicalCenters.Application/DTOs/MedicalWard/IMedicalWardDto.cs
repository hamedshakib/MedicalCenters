using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.MedicalWard
{
    public interface IMedicalWardDto
    {
        string Name { get; set; }
        string Description { get; set; }
        public int Type { get; set; }
    }
}
