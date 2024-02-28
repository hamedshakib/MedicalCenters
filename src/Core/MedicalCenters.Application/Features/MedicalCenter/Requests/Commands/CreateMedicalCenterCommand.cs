using MediatR;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record CreateMedicalCenterCommand : IRequest<BaseValuedCommandResponse>
    {
        public CreateMedicalCenterDto CreateMedicalCenterDto { get; set; }
    }
}
