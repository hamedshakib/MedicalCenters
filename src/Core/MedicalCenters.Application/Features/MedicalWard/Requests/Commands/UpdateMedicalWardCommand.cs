using MediatR;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public record UpdateMedicalWardCommand : IRequest<BaseResponse>
    {
        public MedicalWardDto MedicalWardDto { get; set; }
    }
}
