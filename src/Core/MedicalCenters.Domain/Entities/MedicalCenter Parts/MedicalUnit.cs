﻿using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.Oprerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities
{
    [Table("MedicalUnit")]
    public class MedicalUnit : BaseModifiableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(70)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}