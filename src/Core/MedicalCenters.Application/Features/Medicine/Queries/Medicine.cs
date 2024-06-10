﻿using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Queries
{
    internal class MedicineQueryHandler(IMedicineRepository medicineRepository, IMapper mapper) : IRequestHandler<MedicineQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicineQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await medicineRepository.Get((int)request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException("دارو", request.Id.ToString());
            }

            var dto = mapper.Map<MedicineDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }

    public record class MedicineQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}
