using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Commands
{
    internal class CreateMedicalCenterCommandHandler(IMedicalCenterRepository medicalCenterRepository, IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicalCenterCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();

            var data = mapper.Map<MedicalCenters.Domain.Entities.MedicalCenter>(command.MedicalCenterDto);
            data = await medicalCenterRepository.Add(data);

            await unitOfWork.Save();

            response.IsSuccess = true;
            response.Id = data.Id;



            return response;
        }
    }
    public record CreateMedicalCenterCommand : IRequest<BaseValuedCommandResponse>
    {
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }
}
