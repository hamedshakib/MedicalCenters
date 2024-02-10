using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
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
    internal class DeleteMedicalCenterCommandHandler(IMedicalCentersUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<DeleteMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (await unitOfWork.MedicalCenterRepository.Exist(command.Id))
            {
                await unitOfWork.MedicalCenterRepository.Delete(command.Id);
                await unitOfWork.Save();
            }
            else
            {
                string Object = "مرکز درمانی" + command.Id;
                throw new NotFoundException(Object);
            }

            await unitOfWork.Save();
            response.IsSusses = true;

            return response;
        }
    }
}
