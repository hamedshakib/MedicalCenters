using AutoMapper;
using FluentValidation;
using MediatR;
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
    internal class DeleteMedicalWardCommandHandler(IMedicalWardRepository medicalWardRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicalWardCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await medicalWardRepository.ExistAsync(command.Id))
            {
                throw new NotFoundException(Domain.Entities.MedicalCenter_Parts.MedicalWard.EntityTitle, command.Id.ToString());
            }

            await medicalWardRepository.DeleteAsync(command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;

            return response;
        }
    }

    public record DeleteMedicalWardCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
    internal class DeleteMedicalWardCommandValidator : AbstractValidator<DeleteMedicalWardCommand>
    {
        public DeleteMedicalWardCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}
