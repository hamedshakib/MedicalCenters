using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MedicalCenters.Application.Features.Medicine.Handlers.Commands
{
    internal class UpdateMedicineCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalWard = await unitOfWork.MedicineRepository.Get((int)command.MedicineDto.Id);
            if (medicalWard is null)
            {
                throw new NotFoundException("دارو", command.MedicineDto.Id.ToString());
            }

            mapper.Map(command.MedicineDto, medicalWard);

            await unitOfWork.MedicineRepository.Update(medicalWard);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }
}
