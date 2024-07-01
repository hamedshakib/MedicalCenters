using MedicalCenters.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.Identity.Models.Domains
{
    public class User : BaseUser
    {
        [Key]
        public long Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public byte[] Salt { get; set; }
        [Required]
        public byte[] HashedPassword { get; set; }
        [Required]
        public int HashAlgorithmType { get; set; }
        [Required]
        public int PeaperType { get; set; }
    }
}
