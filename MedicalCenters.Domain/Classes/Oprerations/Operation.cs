using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Oprerations
{
    [Table("Operation")]
    public class Operation : BaseModifiableDomainEntity
    {
        public DateTime OperationDT { get; set; }
        [Required]
        public long OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }
    }
}
