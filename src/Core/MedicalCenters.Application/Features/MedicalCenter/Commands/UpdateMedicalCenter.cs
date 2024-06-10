using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
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
    internal class UpdateMedicalCenterCommandHandler(IMedicalCenterRepository medicalCenterRepository,IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalCenter = await medicalCenterRepository.Get((int)command.Id);
            if (medicalCenter is null)
            {
                throw new NotFoundException("مرکز درمانی", command.Id.ToString());
            }

            mapper.Map(command.MedicalCenterDto, medicalCenter);

            await medicalCenterRepository.Update(medicalCenter);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }
    public record UpdateMedicalCenterCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicalCenterDto MedicalCenterDto { get; set; }
    }
}
