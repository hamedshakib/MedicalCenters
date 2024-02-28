using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Patients
{
    [Table("Patient")]
    public class Patient : Person
    {
        [Key]
        public long Id { get; set; }
    }
}
