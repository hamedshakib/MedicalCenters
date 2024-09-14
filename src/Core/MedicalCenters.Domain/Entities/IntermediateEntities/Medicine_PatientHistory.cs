using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Medicines;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.IntermediateEntities
{
    [PrimaryKey(nameof(MedicineId), nameof(PatientHistoryId))]
    public class Medicine_PatientHistory : BaseCreatableDomainEntity
    {
        [Required]
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        [Required]
        public long PatientHistoryId { get; set; }
        public PatientHistory PatientHistory { get; set; }
    }
}
