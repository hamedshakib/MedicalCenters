using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Persons.Doctor.Commands
{
    internal class DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteDoctorCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (await doctorRepository.Exist((int)command.Id))
            {
                await doctorRepository.Delete((int)command.Id);
                await unitOfWork.Save();
            }
            else
            {
                throw new NotFoundException("پزشک", command.Id.ToString());
            }

            await unitOfWork.Save();
            response.IsSuccess = true;

            return response;
        }
    }
    public record DeleteDoctorCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
