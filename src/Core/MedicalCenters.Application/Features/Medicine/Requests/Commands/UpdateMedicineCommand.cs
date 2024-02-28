using MediatR;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Commands
{
    public class UpdateMedicineCommand : IRequest<BaseResponse>
    {
        public MedicineDto MedicineDto { get; set; }
    }
}
