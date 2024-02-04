using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Patients;
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
        public IList<MedicineType>? MedicineTypes { get; set; }


        public IList<Patient>? Patients { get; set; }
    }
}
