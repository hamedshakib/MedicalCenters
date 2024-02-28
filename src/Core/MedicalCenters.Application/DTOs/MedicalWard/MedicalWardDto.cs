namespace MedicalCenters.Application.DTOs.MedicalWard
{
    public class MedicalWardDto : BaseDto, IMedicalWardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public long MedicalCenterId { get; set; }
    }
}
