using MedicalCenters.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Identity.Models.Domains
{
    [PrimaryKey(nameof(PermissionId), nameof(PermissionGroupId))]
    public class Permission_PermissionGroup : BaseCreatableDomainEntity
    {
        [Required]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        [Required]
        public int PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }
    }
}
