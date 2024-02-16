using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities
{
    [Table("MedicalWard")]
    public class MedicalWard : BaseModifiableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(70)]
        public string Name { get; set; }
        public int TypeId { get; set; }
        public MedicalWardType Type { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public int MedicalCenterId { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
