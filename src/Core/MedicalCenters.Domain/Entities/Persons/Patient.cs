using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Persons
{
    [Table(nameof(Patient))]
    public class Patient : Person
    {
        public new const string EntityTitle = "بیمار";


        [Key]
        public long Id { get; set; }
    }
}
