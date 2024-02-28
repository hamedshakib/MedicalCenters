namespace MedicalCenters.Application.DTOs.MedicalWard
{
    public class CreateMedicalWardDto : IMedicalWardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public long MedicalCenterId { get; set; }
    }
}
