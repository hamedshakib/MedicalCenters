using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.Staffs
{
    [Table("Nurse")]
    public class Nurse : Personnel
    {
        [Key]
        public long Id { get; set; }
    }
}
