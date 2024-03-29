﻿using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities.MedicalCenter_Parts
{
    [Table("MedicalCenterType")]
    public class MedicalCenterType : BaseCreateableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(70)]
        public string Name { get; set; }
    }
}
