using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Commands
{
    internal class DeleteMedicalCenterCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicalCenterCommand, BaseResponse>
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
            response.IsSuccess = true;

            return response;
        }
    }

    public record DeleteMedicalCenterCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
