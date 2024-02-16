using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Oprerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Staffs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Domain.Entities.Patients
{
    [Table("PatientHistory")]
    public class PatientHistory : BaseModifiableDomainEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
