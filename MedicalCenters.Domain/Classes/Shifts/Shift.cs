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
    [Table("Shift")]
    public class Shift : BaseModifiableDomainEntity
    {
        [Key]
        public long Id { get; set; }
        public long? ShiftPlanId { get; set; }
        public ShiftPlan? ShiftPlan { get; set; }
        [Required]
        public long PersonelId { get; set; }
        public Personel Personel { get; set; }

        [Required]
        public int UnitId { get; set; }
        public MedicalUnit Unit { get; set; }
    }
}
