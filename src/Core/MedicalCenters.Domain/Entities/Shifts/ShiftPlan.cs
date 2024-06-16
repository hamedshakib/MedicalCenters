using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Shifts
{
    [Table(nameof(ShiftPlan))]
    public class ShiftPlan : BaseModifiableDomainEntity
    {
        public const string EntityTitle = "برنامه ریزی شیفت";

        [Key]
        public long Id { get; set; }
        [Required]
        public int PersonelId { get; set; }
        public Personnel Personel { get; set; }
        [Required]
        public int MedicalUnitId { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
    }
}
