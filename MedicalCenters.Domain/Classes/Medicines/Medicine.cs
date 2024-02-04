using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Oprerations;
using MedicalCenters.Domain.Classes.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Medicines
{
    [Table("Medicine")]
    public class Medicine : BaseModifiableDomainEntity
    {
        public string Name { get; set; }
        public MedicineType Type { get; set; }



        public IList<Operation>? Operations { get; set; }
        public IList<PatientHistory>? PatientHistories { get; set; }
    }
}
