using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.IntermediateEntities
{
    public class Allergy_MedicineType : BaseCreateableDomainEntity
    {
        [Required]
        public long AllergyId { get; set; }
        public Allergy Allergy { get; set; }

        [Required]
        public long MedicineTypeId { get; set; }
        public MedicineType MedicineType { get; set; }
    }
}
