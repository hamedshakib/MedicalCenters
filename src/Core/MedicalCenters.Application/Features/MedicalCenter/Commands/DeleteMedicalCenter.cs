﻿using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.MedicalCenter.Commands
{
    internal class DeleteMedicalCenterCommandHandler(IMedicalCenterRepository medicalCenterRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await medicalCenterRepository.ExistAsync(command.Id))
            {
                throw new NotFoundException(Domain.Entities.MedicalCenter_Parts.MedicalCenter.EntityTitle, command.Id.ToString());
            }

            await medicalCenterRepository.DeleteAsync(command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            response.IsSuccess = true;

            return response;
        }
    }

    public record DeleteMedicalCenterCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
    internal class DeleteMedicalCenterCommandValidator : AbstractValidator<DeleteMedicalCenterCommand>
    {
        public DeleteMedicalCenterCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}
