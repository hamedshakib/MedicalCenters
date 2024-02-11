﻿using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.Domains
{
    public class User : BaseUser
    {
        [Required, StringLength(150)]
        public string Name { get; set; }
        [Required]
        public byte[] Salt { get; set; }
        [Required]
        public byte[] HashedPassword { get; set; }
        [Required]
        public int HashAlgorithmType { get; set; }
        [Required]
        public int PeaperType { get; set; }

        public IList<Permission> Permissions { get; set; }
        public IList<PermissionGroup> PermissionGroups { get; set; }
    }
}