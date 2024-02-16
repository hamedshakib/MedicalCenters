using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Patients;
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
    [PrimaryKey(nameof(MedicineId), nameof(PatientHistoryId))]
    public class Medicine_PatientHistory : BaseCreateableDomainEntity
    {
        [Required]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Required]
        public long PatientHistoryId { get; set; }
        public PatientHistory PatientHistory { get; set; }
    }
}
