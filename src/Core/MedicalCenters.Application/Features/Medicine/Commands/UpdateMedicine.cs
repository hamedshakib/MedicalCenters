﻿using AutoMapper;
using FluentValidation;
using MediatR;
using MedicalCenters.Application.DTOs;
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
    internal class UpdateMedicineCommandHandler(IMedicineRepository medicineRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var medicalWard = await medicineRepository.GetAsync(command.Id);
            if (medicalWard is null)
            {
                throw new NotFoundException(Domain.Entities.Medicines.Medicine.EntityTitle, command.Id.ToString());
            }

            mapper.Map(command.MedicineDto, medicalWard);

            await medicineRepository.UpdateAsync(medicalWard);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;



            return response;
        }
    }

    public class UpdateMedicineCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public MedicineDto MedicineDto { get; set; }
    }

    internal class UpdateMedicineCommandValidator : AbstractValidator<UpdateMedicineCommand>
    {
        public UpdateMedicineCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(e => e.MedicineDto.Name).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty();
            RuleFor(e => e.MedicineDto.TypeId).NotNull();
        }
    }
}
