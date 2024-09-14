using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.MedicalCenter_Parts
{
    [Table(nameof(MedicalCenterType))]
    public class MedicalCenterType : BaseCreatableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
    }
}
