using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Oprerations;
using MedicalCenters.Domain.Entities.Patients;
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
    [PrimaryKey(nameof(DoctorId), nameof(OperationId))]
    public class Doctor_Operation : BaseCreateableDomainEntity
    {
        [Required]
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public long OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
