using AutoMapper;
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
    internal class AllMedicalCenterQueryHandler(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AllMedicalCentersQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();

            var result = await unitOfWork.MedicalCenterRepository.GetAll();

            List<MedicalCenterDto> dtos = new List<MedicalCenterDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicalCenterDto>(x)));

            response.Data = dtos;
            response.IsSusses = true;


            return response;
        }
    }
}
