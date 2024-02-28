using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Queries
{
    public record MedicalWardQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}
