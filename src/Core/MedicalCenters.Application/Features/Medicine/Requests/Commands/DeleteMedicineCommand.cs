using MediatR;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Commands
{
    public class DeleteMedicineCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
