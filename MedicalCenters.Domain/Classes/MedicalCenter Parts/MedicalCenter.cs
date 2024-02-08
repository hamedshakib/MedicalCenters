using MedicalCenters.Domain.Classes.Base;
using MedicalCenters.Domain.Classes.MedicalCenter_Parts;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenters.Domain.Classes
{
    [Table("MedicalCenter")]
    public class MedicalCenter : BaseModifiableDomainEntity
    {
        [Required,StringLength(70)]
        public string Name { get; set; }
        [Required]
        public MedicalCenterType Type { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public Point? Location { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        public IList<MedicalWard> Wards { get; set; }
    }
}
