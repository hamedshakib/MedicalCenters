using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Queries
{
    public record MedicalCenterQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}
