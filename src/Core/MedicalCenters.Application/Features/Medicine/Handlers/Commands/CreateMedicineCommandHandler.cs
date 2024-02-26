using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Handlers.Commands
{
    public class CreateMedicineCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicineCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();

            var data = mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.CreateMedicineDto);
            data = await unitOfWork.MedicineRepository.Add(data);

            await unitOfWork.Save();

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }
}
