using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Shifts
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
        public Personnel Personel { get; set; }

        [Required]
        public int UnitId { get; set; }
        public MedicalUnit Unit { get; set; }
    }
}
