using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalWard.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Commands
{
    internal class CreateMedicalWardCommandHandler(IMedicalWardRepository medicalWardRepository,IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicalWardCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();

            var data = mapper.Map<MedicalCenters.Domain.Entities.MedicalWard>(command.MedicalWardDto);
            data = await medicalWardRepository.Add(data);

            await unitOfWork.Save();

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }
    public class CreateMedicalWardCommand : IRequest<BaseValuedCommandResponse>
    {
        public MedicalWardDto MedicalWardDto { get; set; }
    }
}
