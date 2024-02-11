using MedicalCenters.Domain.Classes.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Models.Domains
{
    public class PermissionGroup_User : BaseCreateableDomainEntity
    {
        [Required]
        public long PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
