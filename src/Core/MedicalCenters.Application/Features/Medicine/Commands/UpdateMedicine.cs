using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Commands
{
    internal class UpdateMedicineCommandHandler(IMedicineRepository medicineRepository, IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalWard = await medicineRepository.Get(command.Id);
            if (medicalWard is null)
            {
                throw new NotFoundException("دارو", command.Id.ToString());
            }

            mapper.Map(command.MedicineDto, medicalWard);

            await medicineRepository.Update(medicalWard);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }

    public class UpdateMedicineCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicineDto MedicineDto { get; set; }
    }
}
