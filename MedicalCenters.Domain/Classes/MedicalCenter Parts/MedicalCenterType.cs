using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Classes.MedicalCenter_Parts
{
    [Table("MedicalCenterType")]
    public class MedicalCenterType : BaseCreateableDomainEntity
    {
        [Required,StringLength(70)]
        public string Name { get; set; }
    }
}
