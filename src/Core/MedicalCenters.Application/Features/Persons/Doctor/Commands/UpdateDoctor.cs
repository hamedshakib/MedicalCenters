using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
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
    internal class UpdateDoctorCommandHandler(IDoctorRepository doctorRepository,IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateDoctorCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var doctor = await doctorRepository.Get(command.Id);
            if (doctor is null)
            {
                throw new NotFoundException("پزشک", command.Id.ToString());
            }

            mapper.Map(command.DoctorDto, doctor);

            await doctorRepository.Update(doctor);
            await unitOfWork.Save();

            response.IsSuccess = true;



            return response;
        }
    }
    public record UpdateDoctorCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
        public DoctorDto DoctorDto { get; set; }
    }
}
