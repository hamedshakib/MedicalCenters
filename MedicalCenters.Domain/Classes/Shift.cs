using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    public class Shift : BaseModifiableDomainEntity
    {
        public ShiftPlan ShiftPlan {  get; set; }
        public Personel Personel { get; set; }
        public MedicalUnit Unit { get; set; }
    }
}
