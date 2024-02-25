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

            if (await unitOfWork.MedicalCenterRepository.Exist((int)command.Id))
            {
                await unitOfWork.MedicalCenterRepository.Delete((int)command.Id);
                await unitOfWork.Save();
            }
            else
            {
                throw new NotFoundException("مرکز درمانی", command.Id.ToString());
            }

            await unitOfWork.Save();
            response.IsSusses = true;

            return response;
        }
    }
}
