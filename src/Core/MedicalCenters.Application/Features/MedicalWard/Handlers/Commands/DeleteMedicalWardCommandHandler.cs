using AutoMapper;
using Azure.Core;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Validates;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Handlers.Commands
{
    internal class DeleteMedicalWardCommandHandler(IMedicalCentersUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<DeleteMedicalWardCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (await unitOfWork.MedicalWardRepository.Exist((int)command.Id))
            {
                await unitOfWork.MedicalWardRepository.Delete((int)command.Id);
                await unitOfWork.Save();
            }
            else
            {
                throw new NotFoundException("بخش درمانی", command.Id.ToString());
            }

            await unitOfWork.Save();
            response.IsSusses = true;

            return response;
        }
    }
}
