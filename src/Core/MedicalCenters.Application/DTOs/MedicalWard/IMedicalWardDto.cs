namespace MedicalCenters.Application.DTOs.MedicalWard
{
    public interface IMedicalWardDto
    {
        string Name { get; set; }
        string Description { get; set; }
        public int TypeId { get; set; }
        public long MedicalCenterId { get; set; }
    }
}
