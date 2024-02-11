using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.Staffs;
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
    [PrimaryKey(nameof(PermissionGroupId), nameof(UserId))]
    public class PermissionGroup_User : BaseCreateableDomainEntity
    {
        [Required]
        public int PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
