using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Oprerations
{
    [Table(nameof(OperationType))]
    public class OperationType : BaseCreatableDomainEntity
    {
        public new const string EntityTitle = "نوع عمل";

        [Key]
        public int Id { get; set; }
        [Required, MaxLength(70)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
