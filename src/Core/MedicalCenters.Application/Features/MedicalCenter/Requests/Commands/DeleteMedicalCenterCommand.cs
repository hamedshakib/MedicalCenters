using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record DeleteMedicalCenterCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
