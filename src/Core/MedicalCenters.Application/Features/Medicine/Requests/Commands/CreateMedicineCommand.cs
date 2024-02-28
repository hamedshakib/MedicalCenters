using MediatR;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Commands
{
    public class CreateMedicineCommand : IRequest<BaseValuedCommandResponse>
    {
        public CreateMedicineDto CreateMedicineDto { get; set; }
    }
}
