using AutoMapper;
using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalWard.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.Features.MedicalWard.Queries
{
    internal class AllMedicalCenterWardsQueryHandler(IMedicalWardRepository medicalWardRepository, IMapper mapper) : IRequestHandler<AllMedicalCenterWardsQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicalCenterWardsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await medicalWardRepository.GetAllMedicalCenterWardsAsync(request.MedicalCenterId, cancellationToken);

            List<MedicalWardDto> dtos = new List<MedicalWardDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicalWardDto>(x)));

            response.Data = dtos;
            response.IsSuccess = true;


            return response;
        }
    }

    public record AllMedicalCenterWardsQuery : IRequest<BaseQueryResponse>
    {
        public int MedicalCenterId { get; set; }
    }
}
