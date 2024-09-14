using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.Medicine.Commands
{
    internal class DeleteMedicineCommandHandler(IMedicineRepository medicineRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!await medicineRepository.ExistAsync(command.Id))
            {
                throw new NotFoundException(Domain.Entities.Medicines.Medicine.EntityTitle, command.Id.ToString());
            }

            await medicineRepository.DeleteAsync(command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;

            return response;
        }
    }

    public class DeleteMedicineCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }

    internal class DeleteMedicineCommandValidator : AbstractValidator<DeleteMedicineCommand>
    {
        public DeleteMedicineCommandValidator()
        {
            RuleFor(e => e.Id).NotNull();
        }
    }
}
