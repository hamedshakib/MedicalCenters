using System.ComponentModel.DataAnnotations;


namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class Personnel : Person
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(50)]
        public string PersonnelCode { get; set; }
    }
}
