using System.ComponentModel.DataAnnotations;


namespace MedicalCenters.Domain.Entities.Base
{
    public abstract class Personnel : Person
    {
        public const int MaxPersonnelCodeLength = 50;

        [Key]
        public long Id { get; set; }
        [Required, StringLength(MaxPersonnelCodeLength)]
        public string PersonnelCode { get; set; }
    }
}
