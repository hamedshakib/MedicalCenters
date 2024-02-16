using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.Oprerations
{
    [Table("Operation")]
    public class Operation : BaseModifiableDomainEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime OperationDT { get; set; }
        [Required]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
    }
}
