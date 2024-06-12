using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Persons.Staffs
{
    [Table("Doctor")]
    public class Doctor : Personnel
    {
        public const string EntityTitle = "پزشک";

        [Key]
        public int Id { get; set; }
    }
}
