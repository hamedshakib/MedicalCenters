﻿using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Medicines;
using MedicalCenters.Domain.Classes.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.Domains
{
    [PrimaryKey(nameof(PermissionId), nameof(PermissionGroupId))]
    public class Permission_PermissionGroup :BaseCreateableDomainEntity
    {
        [Required]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        [Required]
        public int PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }
    }
}
