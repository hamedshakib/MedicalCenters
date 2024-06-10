using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalWard.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Commands
{
    internal class DeleteMedicalWardCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicalWardCommand, BaseResponse>
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
            response.IsSuccess = true;

            return response;
        }
    }

    public record DeleteMedicalWardCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
