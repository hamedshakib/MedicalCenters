using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Commands
{
    internal class CreateMedicineCommandHandler(IMedicineRepository medicineRepository,IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicineCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();

            var data = mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.MedicineDto);
            data = await medicineRepository.Add(data);

            await unitOfWork.Save();

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }

    public class CreateMedicineCommand : IRequest<BaseValuedCommandResponse>
    {
        public MedicineDto MedicineDto { get; set; }
    }
}
