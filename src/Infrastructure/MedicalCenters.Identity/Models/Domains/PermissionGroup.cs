using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Identity.Models.Domains
{
    public class PermissionGroup : BaseModifiableDomainEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
