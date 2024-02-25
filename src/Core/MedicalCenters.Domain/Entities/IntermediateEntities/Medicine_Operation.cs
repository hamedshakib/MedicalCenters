using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Oprerations;
using MedicalCenters.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.IntermediateEntities
{
    [PrimaryKey(nameof(MedicineId), nameof(OperationId))]
    public class Medicine_Operation : BaseCreateableDomainEntity
    {
        [Required]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Required]
        public long OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
