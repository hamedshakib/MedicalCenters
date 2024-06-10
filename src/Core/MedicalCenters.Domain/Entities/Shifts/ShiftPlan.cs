using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Shifts
{
    [Table("ShiftPlan")]
    public class ShiftPlan : BaseModifiableDomainEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long PersonelId { get; set; }
        public Personnel Personel { get; set; }
        [Required]
        public int MedicalUnitId { get; set; }
        public MedicalUnit MedicalUnit { get; set; }
    }
}
