using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public record UpdateMedicalWardCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicalWardDto MedicalWardDto { get; set; }
    }
}
