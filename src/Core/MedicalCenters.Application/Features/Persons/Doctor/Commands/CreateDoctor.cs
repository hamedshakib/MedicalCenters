using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Persons.Doctor.Commands
{
    public class CreateDoctorCommandHandler(IDoctorRepository doctorRepository,IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateDoctorCommand, BaseValuedCommandResponse>
    {
        public async Task<BaseValuedCommandResponse> Handle(CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse();

            var data = mapper.Map<MedicalCenters.Domain.Entities.Staffs.Doctor>(command.DoctorDto);
            data = await doctorRepository.Add(data);

            await unitOfWork.Save();

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }
    public record CreateDoctorCommand : IRequest<BaseValuedCommandResponse>
    {
        public DoctorDto DoctorDto { get; set; }
    }
}
