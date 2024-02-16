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
    [PrimaryKey(nameof(AllergyId), nameof(PatientId))]
    public class Allergy_Patient : BaseCreateableDomainEntity
    {
        [Required]
        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }

        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
