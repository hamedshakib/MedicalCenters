using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes
{
    [Table("Allergy")]
    public class Allergy : BaseModifiableDomainEntity
    {
        [Required,StringLength(100)]
        public string Name {  get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public IList<MedicineType>? MedicineTypes { get; set; }


        public IList<Patient>? Patients { get; set; }
    }
}
