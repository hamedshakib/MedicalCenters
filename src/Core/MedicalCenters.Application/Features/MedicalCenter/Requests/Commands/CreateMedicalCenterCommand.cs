using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record CreateMedicalCenterCommand : IRequest<BaseValuedCommandResponse>
    {
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }
}
