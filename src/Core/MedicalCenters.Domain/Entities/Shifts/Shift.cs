using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Domain.Entities.Shifts
{
    [Table(nameof(Shift))]
    public class Shift : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "شیفت";
        [Key]
        public long Id { get; set; }
        public long? ShiftPlanId { get; set; }
        public ShiftPlan? ShiftPlan { get; set; }
        [Required]
        public int PersonnelId { get; set; }
        public Personnel Personnel { get; set; }

        [Required]
        public int UnitId { get; set; }
        public MedicalUnit Unit { get; set; }
    }
}
