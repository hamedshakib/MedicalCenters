using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Queries
{
    public record AllMedicalCentersQuery : IRequest<BaseQueryResponse>
    {

    }
}
