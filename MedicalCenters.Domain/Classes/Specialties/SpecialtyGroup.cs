using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.Specialties
{
    [Table("SpecialtyGroup")]
    public class SpecialtyGroup : BaseCreateableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name { get; set; }
        [Required,StringLength(1000)]
        public string Description { get; set; }
    }
}
