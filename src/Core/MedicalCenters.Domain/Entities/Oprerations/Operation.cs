using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Oprerations
{
    [Table(nameof(Operation))]
    public class Operation : BaseModifiableDomainEntity
    {
        public const string EntityTitle = "عمل";

        [Key]
        public long Id { get; set; }
        public DateTime OperationDT { get; set; }
        [Required]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
    }
}
