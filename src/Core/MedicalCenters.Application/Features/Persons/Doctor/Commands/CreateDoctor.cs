using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
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
    public class CreateDoctorCommandHandler(IDoctorRepository doctorRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateDoctorCommand, BaseValuedCommandResponse<int>>
    {
        public async Task<BaseValuedCommandResponse<int>> Handle(CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse<int>();

            var data = mapper.Map<Domain.Entities.Persons.Staffs.Doctor>(command.DoctorDto);
            data = await doctorRepository.Add(data);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }
    public record CreateDoctorCommand : IRequest<BaseValuedCommandResponse<int>>
    {
        public DoctorDto DoctorDto { get; set; }
    }

    internal class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand> 
    {
        public CreateDoctorCommandValidator()
        {
            RuleFor(e => e.DoctorDto.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Staffs.Doctor.MaxFistNameLenght);
            RuleFor(e => e.DoctorDto.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(Domain.Entities.Persons.Staffs.Doctor.MaxLastNameLenght);
            RuleFor(e => e.DoctorDto.NationalCode).NotNull().NotEmpty().MaximumLength(Domain.Entities.Persons.Staffs.Doctor.MaxNationalCodeLenght);
            RuleFor(e => e.DoctorDto.PersonnelCode).NotNull().NotEmpty().MaximumLength(Personnel.MaxPersonnelCodeLength);
        }
    }
}
