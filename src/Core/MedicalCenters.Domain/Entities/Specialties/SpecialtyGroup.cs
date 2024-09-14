using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Specialties
{
    [Table(nameof(SpecialtyGroup))]
    public class SpecialtyGroup : BaseCreatableDomainEntity
    {
        public new const string EntityTitle = "گروه تخصص";

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }
    }
}
