using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalWard.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Queries
{
    internal class MedicalWardQueryHandler(IMedicalWardRepository medicalWardRepository, IMapper mapper) : IRequestHandler<MedicalWardQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicalWardQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await medicalWardRepository.Get((int)request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException("بخش درمانی", request.Id.ToString());
            }

            var dto = mapper.Map<MedicalWardDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }

    public record MedicalWardQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}
