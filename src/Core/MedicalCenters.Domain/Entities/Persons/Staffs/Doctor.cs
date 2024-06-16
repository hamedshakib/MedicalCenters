using MedicalCenters.Domain.Entities.Persons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Persons.Staffs
{
    [Table(nameof(Doctor))]
    public class Doctor : Personnel
    {
        public const string EntityTitle = "پزشک";
    }
}
