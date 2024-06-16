using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Persons;
using MedicalCenters.Domain.Entities.Persons.Staffs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities
{
    [Table(nameof(PatientHistory))]
    public class PatientHistory : BaseModifiableDomainEntity
    {
        public const string EntityTitle = "سابقه بیمار";

        [Key]
        public long Id { get; set; }
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
