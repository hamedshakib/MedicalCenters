﻿using MedicalCenters.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Domain.Entities.Oprerations
{
    [Table("OperationType")]
    public class OperationType : BaseCreateableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(70)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}