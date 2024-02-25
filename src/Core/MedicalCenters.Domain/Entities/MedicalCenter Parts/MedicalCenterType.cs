using MedicalCenters.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.MedicalCenter_Parts
{
    [Table("MedicalCenterType")]
    public class MedicalCenterType : BaseCreateableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(70)]
        public string Name { get; set; }
    }
}
