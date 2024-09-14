using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;

namespace MedicalCenters.Domain.Entities.Shifts
{
    [Table(nameof(ShiftPlan))]
    public class ShiftPlan : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "برنامه ریزی شیفت";

        [Key]
        public long Id { get; set; }
        [Required]
        public int PersonnelId { get; set; }
        public Personnel Personnel { get; set; }
        [Required]
        public int MedicalUnitId { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
    }
}
