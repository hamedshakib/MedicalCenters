using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalWard.Commands;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Commands
{
    internal class DeleteMedicalWardCommandHandler(IMedicalWardRepository medicalWardRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicalWardCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicalWardCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if (!await medicalWardRepository.Exist(command.Id))
            {
                throw new NotFoundException(Domain.Entities.MedicalWard.EntityTitle, command.Id.ToString());
            }

            await medicalWardRepository.Delete(command.Id);
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
