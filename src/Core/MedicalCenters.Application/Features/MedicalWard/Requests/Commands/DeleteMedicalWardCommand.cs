using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public record DeleteMedicalWardCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
