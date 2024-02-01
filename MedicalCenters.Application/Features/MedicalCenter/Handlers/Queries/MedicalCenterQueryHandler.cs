using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Queries
{
    internal class MedicalCenterQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<MedicalCenterQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(MedicalCenterQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            try
            {
                var result = await unitOfWork.MedicalCenterRepository.Get(request.Id);

                var dto = mapper.Map<MedicalCenterDto>(result);

                response.Data = dto;
                response.IsSusses = true;
            }
            catch (ApplicationException ex)
            {
                response.IsSusses = false;
                response.Errors ??= new List<ErrorResponse>();
                response.Errors.Add(new ErrorResponse(2000, ex.Message));
            }
            catch (Exception ex)
            {
                response.IsSusses = false;
                response.Errors ??= new List<ErrorResponse>();
                response.Errors.Add(new ErrorResponse(-1, ex.Message));
            }

            return response;
        }
    }
}
