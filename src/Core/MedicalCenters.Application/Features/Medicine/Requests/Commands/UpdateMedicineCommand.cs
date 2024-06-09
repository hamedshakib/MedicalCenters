using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Commands
{
    public class UpdateMedicineCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicineDto MedicineDto { get; set; }
    }
}
