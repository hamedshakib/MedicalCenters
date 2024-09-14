using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalCenters.Domain.Entities.Base;

namespace MedicalCenters.Domain.Entities.MedicalCenter_Parts
{
    [Table(nameof(MedicalUnit))]
    public class MedicalUnit : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "واحد درمانی";

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
