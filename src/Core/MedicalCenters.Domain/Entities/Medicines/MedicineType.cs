using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Medicines
{
    [Table(nameof(MedicineType))]
    public class MedicineType : BaseCreateableDomainEntity
    {
        public const string EntityTitle = "نوع دارو";

        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(1000)]
        public string Description { get; set; }

    }
}
