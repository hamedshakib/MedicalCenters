using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Specialties
{
    [Table(nameof(SpecialtyGroup))]
    public class SpecialtyGroup : BaseCreateableDomainEntity
    {
        public const string EntityTitle = "گروه تخصص";

        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }
    }
}
