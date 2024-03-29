﻿using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Responses;

namespace MedicalCenters.Application.Features.Medicine.Handlers.Commands
{
    internal class DeleteMedicineCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (await unitOfWork.MedicineRepository.Exist((int)command.Id))
            {
                await unitOfWork.MedicineRepository.Delete((int)command.Id);
                await unitOfWork.Save();
            }
            else
            {
                throw new NotFoundException("دارو", command.Id.ToString());
            }

            await unitOfWork.Save();
            response.IsSuccess = true;

            return response;
        }
    }
}
