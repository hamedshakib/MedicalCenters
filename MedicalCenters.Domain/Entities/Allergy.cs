using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Domain.Entities.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities
{
    [Table("Allergy")]
    public class Allergy : BaseModifiableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Name {  get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
