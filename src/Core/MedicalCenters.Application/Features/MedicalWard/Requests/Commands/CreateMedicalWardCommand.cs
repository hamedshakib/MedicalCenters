using MediatR;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public class CreateMedicalWardCommand : IRequest<BaseValuedCommandResponse>
    {
        public CreateMedicalWardDto CreateMedicalWardDto { get; set; }
    }
}
