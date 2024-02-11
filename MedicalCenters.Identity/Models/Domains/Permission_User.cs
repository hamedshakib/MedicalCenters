using MedicalCenters.Domain.Classes.Base;
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
    [PrimaryKey(nameof(PermissionId), nameof(UserId))]
    public class Permission_User : BaseCreateableDomainEntity
    {
        [Required]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
