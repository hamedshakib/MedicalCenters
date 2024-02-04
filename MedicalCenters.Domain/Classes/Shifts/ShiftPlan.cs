using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Shifts
{
    [Table("ShiftPlan")]
    public class ShiftPlan : BaseModifiableDomainEntity
    {
        public Personel Personel { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
    }
}
