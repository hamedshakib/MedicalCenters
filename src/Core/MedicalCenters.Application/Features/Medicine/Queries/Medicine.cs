﻿using AutoMapper;
using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.Medicine.Queries
{
    internal class MedicineQueryHandler(IMedicineRepository medicineRepository, IMapper mapper) : IRequestHandler<MedicineQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicineQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await medicineRepository.GetAsync(request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException(Domain.Entities.Medicines.Medicine.EntityTitle, request.Id.ToString());
            }

            var dto = mapper.Map<MedicineDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }

    public record class MedicineQuery : IRequest<BaseQueryResponse>
    {
        public int Id { get; set; }
    }
}
