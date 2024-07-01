using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Identity.Models.Domains
{
    public class PermissionGroup : BaseModifiableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
