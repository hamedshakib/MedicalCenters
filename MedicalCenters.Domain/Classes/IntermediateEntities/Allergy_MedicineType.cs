using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.IntermediateEntities
{
    [PrimaryKey(nameof(AllergyId), nameof(MedicineTypeId))]
    public class Allergy_MedicineType : BaseCreateableDomainEntity
    {
        [Required]
        public int AllergyId { get; set; }
        public Allergy Allergy { get; set; }

        [Required]
        public int MedicineTypeId { get; set; }
        public MedicineType MedicineType { get; set; }
    }
}
