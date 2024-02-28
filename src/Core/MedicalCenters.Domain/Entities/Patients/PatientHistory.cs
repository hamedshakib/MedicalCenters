using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Staffs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
