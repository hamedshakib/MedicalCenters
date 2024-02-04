using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Oprerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Staffs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Classes.Patients
{
    [Table("PatientHistory")]
    public class PatientHistory : BaseModifiableDomainEntity
    {
        [Required]
        public Patient Patient { get; set; }
        public IList<Operation>? Operations { get; set; }
        public IList<Medicine>? Medicines { get; set; }
        public Doctor Doctor { get; set; }
    }
}
