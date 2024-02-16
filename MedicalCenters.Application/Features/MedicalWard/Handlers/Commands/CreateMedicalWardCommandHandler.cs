using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Handlers.Commands
{
    internal class CreateMedicalWardCommandHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicalWardCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();

            var data = mapper.Map<MedicalCenters.Domain.Entities.MedicalWard>(command.CreateMedicalWardDto);
            data = await unitOfWork.MedicalWardRepository.Add(data);

            await unitOfWork.Save();

            response.IsSusses = true;
            response.Id = data.Id;


            return response;
        }
    }
}
