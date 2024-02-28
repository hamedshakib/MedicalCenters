using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.MedicalCenter_Parts
{
    [Table("MedicalWardType")]
    public class MedicalWardType : BaseCreateableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(70)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
