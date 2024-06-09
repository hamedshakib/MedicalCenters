using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public class CreateMedicalWardCommand : IRequest<BaseValuedCommandResponse>
    {
        public MedicalWardDto MedicalWardDto { get; set; }
    }
}
