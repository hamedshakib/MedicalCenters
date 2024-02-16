using MediatR;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Requests.Commands
{
    public class CreateMedicineCommand : IRequest<BaseValuedCommandResponse>
    {
        public CreateMedicineDto CreateMedicineDto { get; set; }
    }
}
