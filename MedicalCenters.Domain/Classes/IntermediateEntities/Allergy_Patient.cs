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
    public class Allergy_Patient : BaseCreateableDomainEntity
    {
        [Required]
        public long AllergyId { get; set; }
        public Allergy Allergy { get; set; }

        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
