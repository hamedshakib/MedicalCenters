﻿using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Queries
{
    internal class MedicalCenterQueryHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicalCenterQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicalCenterQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await unitOfWork.MedicalCenterRepository.Get((int)request.Id,cancellationToken);

            if (result == null)
            {
                throw new NotFoundException("مرکز درمانی", request.Id.ToString());
            }

            var dto = mapper.Map<MedicalCenterDto>(result);

            response.Data = dto;
            response.IsSusses = true;

            return response;
        }
    }
}