﻿using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalWard.Commands;
using MedicalCenters.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.MedicalWard.Commands
{
    internal class UpdateMedicalWardCommandHandler(IMedicalWardRepository medicalWardRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicalWardCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalWard = await medicalWardRepository.GetAsync(command.Id);
            if (medicalWard is null)
            {
                throw new NotFoundException(Domain.Entities.MedicalCenter_Parts.MedicalWard.EntityTitle, command.Id.ToString());
            }

            mapper.Map(command.MedicalWardDto, medicalWard);

            await medicalWardRepository.UpdateAsync(medicalWard);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;



            return response;
        }
    }

    public record UpdateMedicalWardCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicalWardDto MedicalWardDto { get; set; }
    }
    internal class UpdateMedicalWardCommandValidator : AbstractValidator<UpdateMedicalWardCommand>
    {
        public UpdateMedicalWardCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(e => e.MedicalWardDto.Name).Cascade(CascadeMode.Stop).NotNull().NotEmpty();
            RuleFor(e => e.MedicalWardDto.TypeId).NotNull();
            RuleFor(e => e.MedicalWardDto.MedicalCenterId).NotNull();
        }
    }
}
