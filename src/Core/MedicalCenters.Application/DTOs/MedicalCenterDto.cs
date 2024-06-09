using System.Text.Json.Serialization;

namespace MedicalCenters.Application.DTOs
{
    public record MedicalCenterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string Address { get; set; }
        [JsonPropertyName("gpsx")]
        public double? GPSx { get; set; }
        [JsonPropertyName("gpsy")]
        public double? GPSy { get; set; }
    }
}
