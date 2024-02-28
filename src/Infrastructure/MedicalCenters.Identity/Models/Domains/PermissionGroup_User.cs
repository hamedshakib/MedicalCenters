using MedicalCenters.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
