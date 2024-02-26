using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Validates;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Commands
{
    internal class UpdateMedicalCenterCommandHandler(IMedicalCentersUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<UpdateMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalCenter=await unitOfWork.MedicalCenterRepository.Get((int)command.MedicalCenterDto.Id);
            if (medicalCenter is null)
            {
                throw new NotFoundException("مرکز درمانی", command.MedicalCenterDto.Id.ToString());
            }

            mapper.Map(command.MedicalCenterDto, medicalCenter);

            await unitOfWork.MedicalCenterRepository.Update(medicalCenter);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }
}
