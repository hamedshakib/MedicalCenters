using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.IntermediateEntities
{
    public class Medicine_PatientHistory : BaseCreateableDomainEntity
    {
        [Required]
        public long MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Required]
        public long PatientHistoryId { get; set; }
        public PatientHistory PatientHistory { get; set; }
    }
}
