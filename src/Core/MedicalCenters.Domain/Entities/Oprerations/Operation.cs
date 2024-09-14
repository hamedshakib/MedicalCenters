using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Oprerations
{
    [Table(nameof(Operation))]
    public class Operation : BaseModifiableDomainEntity
    {
        public new const string EntityTitle = "عمل";

        [Key]
        public long Id { get; set; }
        public DateTime OperationAt { get; set; }
        [Required]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
    }
}
