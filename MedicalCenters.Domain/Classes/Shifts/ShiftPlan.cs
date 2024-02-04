using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Shifts
{
    [Table("ShiftPlan")]
    public class ShiftPlan : BaseModifiableDomainEntity
    {
        [Required]
        public Personel Personel { get; set; }
        [Required]
        public MedicalUnit MedicalUnit { get; set; }
    }
}
