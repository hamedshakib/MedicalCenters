using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Requests.Commands
{
    public class CreateMedicineCommand : IRequest<BaseValuedCommandResponse>
    {
        public MedicineDto MedicineDto { get; set; }
    }
}
