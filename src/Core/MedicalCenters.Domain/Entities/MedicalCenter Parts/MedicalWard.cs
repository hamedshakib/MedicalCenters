using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities
{
    [Table(nameof(MedicalWard))]
    public class MedicalWard : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "بخش درمانی";

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        public int TypeId { get; set; }
        public MedicalWardType Type { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public int MedicalCenterId { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
