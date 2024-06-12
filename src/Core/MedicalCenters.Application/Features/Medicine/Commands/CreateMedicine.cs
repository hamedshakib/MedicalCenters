using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Features.Persons.Doctor.Commands;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Commands
{
    internal class CreateMedicineCommandHandler(IMedicineRepository medicineRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateMedicineCommand, BaseValuedCommandResponse<int>>
    {
        public async Task<BaseValuedCommandResponse<int>> Handle(CreateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseValuedCommandResponse<int>();

            var data = mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.MedicineDto);
            data = await medicineRepository.Add(data);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Id = data.Id;


            return response;
        }
    }

    public class CreateMedicineCommand : IRequest<BaseValuedCommandResponse<int>>
    {
        public MedicineDto MedicineDto { get; set; }
    }

    internal class CreateMedicineCommandValidator : AbstractValidator<CreateMedicineCommand>
    {
        public CreateMedicineCommandValidator()
        {
            RuleFor(e => e.MedicineDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.MedicineDto.TypeId).NotNull();
        }
    }
}
