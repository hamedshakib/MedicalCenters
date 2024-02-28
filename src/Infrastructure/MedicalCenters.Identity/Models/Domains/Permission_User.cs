using MedicalCenters.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
