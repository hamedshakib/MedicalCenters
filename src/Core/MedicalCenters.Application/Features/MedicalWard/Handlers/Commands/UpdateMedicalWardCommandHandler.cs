﻿using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
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
    internal class UpdateMedicalWardCommandHandler(IMedicalCentersUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<UpdateMedicalWardCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalWard=await unitOfWork.MedicalWardRepository.Get((int)command.MedicalWardDto.Id);
            if (medicalWard is null)
            {
                throw new NotFoundException("بخش درمانی", command.MedicalWardDto.Id.ToString());
            }

            mapper.Map(command.MedicalWardDto, medicalWard);

            await unitOfWork.MedicalWardRepository.Update(medicalWard);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }
}
