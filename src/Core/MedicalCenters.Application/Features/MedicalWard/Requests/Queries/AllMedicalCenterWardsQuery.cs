using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Queries
{
    public record AllMedicalCenterWardsQuery : IRequest<BaseQueryResponse>
    {
        public long MedicalCenterId { get; set; }
    }
}
