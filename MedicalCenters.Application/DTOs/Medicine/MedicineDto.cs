using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.DTOs.Medicine
{
    public class MedicineDto : BaseDto,IMedicineDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}
