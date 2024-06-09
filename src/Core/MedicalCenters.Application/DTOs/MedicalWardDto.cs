namespace MedicalCenters.Application.DTOs
{
    public record MedicalWardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public long MedicalCenterId { get; set; }
    }
}
