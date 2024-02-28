using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
