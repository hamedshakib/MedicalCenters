using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.Medicine
{
    public interface IMedicineDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}
