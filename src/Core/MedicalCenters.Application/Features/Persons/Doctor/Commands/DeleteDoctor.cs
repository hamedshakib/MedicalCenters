﻿using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.Persons.Doctor.Commands
{
    internal class DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteDoctorCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await doctorRepository.ExistAsync(command.Id))
            {
                throw new NotFoundException(Domain.Entities.Persons.Staffs.Doctor.EntityTitle, command.Id.ToString());
            }

            await doctorRepository.DeleteAsync(command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            response.IsSuccess = true;

            return response;
        }
    }
    public record DeleteDoctorCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
    internal class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}
