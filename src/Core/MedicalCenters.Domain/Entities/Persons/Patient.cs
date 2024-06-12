using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Persons
{
    [Table("Patient")]
    public class Patient : Person
    {
        public const string EntityTitle = "بیمار";


        [Key]
        public long Id { get; set; }
    }
}
