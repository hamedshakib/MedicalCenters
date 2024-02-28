using MediatR;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record UpdateMedicalCenterCommand : IRequest<BaseResponse>
    {
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }
}
