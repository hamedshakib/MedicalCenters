using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Medicines;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.IntermediateEntities
{
    [PrimaryKey(nameof(AllergyId), nameof(MedicineTypeId))]
    public class Allergy_MedicineType : BaseCreatableDomainEntity
    {
        [Required]
        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }

        [Required]
        public int MedicineTypeId { get; set; }
        public MedicineType MedicineType { get; set; }
    }
}
