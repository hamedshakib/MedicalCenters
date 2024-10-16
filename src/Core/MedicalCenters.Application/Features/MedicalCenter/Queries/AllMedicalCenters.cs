﻿using AutoMapper;
using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalCenter.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.MedicalCenter.Queries
{
    internal class AllMedicalCenterQueryHandler(IMedicalCenterRepository medicalCenterRepository, IMapper mapper) : IRequestHandler<AllMedicalCentersQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await medicalCenterRepository.GetAllAsync(cancellationToken);

            List<MedicalCenterDto> dtos = new List<MedicalCenterDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicalCenterDto>(x)));

            response.Data = dtos;
            response.IsSuccess = true;


            return response;
        }
    }

    public record AllMedicalCentersQuery : IRequest<BaseQueryResponse>
    {

    }
}
