using MedicalCenters.Domain.Entities.Base;
using MedicalCenters.Domain.Entities.MedicalCenter_Parts;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Entities
{
    [Table(nameof(MedicalCenter))]
    public class MedicalCenter : BaseModifiableDomainEntity
    {
        public const string EntityTitle = "مرکز درمانی";


        [Key]
        public int Id { get; set; }
        [Required, StringLength(70)]
        public string Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        public MedicalCenterType Type { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public Point? Location { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
    }
}
