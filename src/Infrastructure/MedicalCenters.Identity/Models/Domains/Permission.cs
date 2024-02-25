﻿using MedicalCenters.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.Domains
{
    public class Permission : BaseCreateableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
