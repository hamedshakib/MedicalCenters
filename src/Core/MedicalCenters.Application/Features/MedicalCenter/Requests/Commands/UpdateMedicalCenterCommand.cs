using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record UpdateMedicalCenterCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }
}
