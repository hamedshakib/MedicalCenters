using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("Allergy")]
    public class Allergy : BaseModifiableDomainEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public MedicineType MedicineType { get; set; }
    }
}
