using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using MedicalCenters.Domain.Entities.Persons;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Persons.Doctor.Commands
{
    internal class UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateDoctorCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var doctor = await doctorRepository.GetAsync(command.Id);
            if (doctor is null)
            {
                throw new NotFoundException(Domain.Entities.Persons.Staffs.Doctor.EntityTitle, command.Id.ToString());
            }

            mapper.Map(command.DoctorDto, doctor);

            await doctorRepository.UpdateAsync(doctor);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;



            return response;
        }
    }
    public record UpdateDoctorCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public DoctorDto DoctorDto { get; set; }
    }

    internal class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.DoctorDto.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Staffs.Doctor.MaxFistNameLength);
            RuleFor(e => e.DoctorDto.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Staffs.Doctor.MaxLastNameLength);
            RuleFor(e => e.DoctorDto.NationalCode).NotNull().NotEmpty().MaximumLength(Domain.Entities.Persons.Staffs.Doctor.MaxNationalCodeLength);
            RuleFor(e => e.DoctorDto.PersonnelCode).NotNull().NotEmpty().MaximumLength(Personnel.MaxPersonnelCodeLength);
        }
    }
}
