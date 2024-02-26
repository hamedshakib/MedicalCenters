using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using MedicalCenters.Application.Features.Medicine.Requests.Queries;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Handlers.Queries
{
    internal class AllMedicineMedicineTypeQueryHanlder(IMedicalCentersUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AllMedicineTypeMedicinesQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicineTypeMedicinesQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await unitOfWork.MedicineRepository.GetAllMedicineTypeMedicines((int)request.MedicineTypeId, cancellationToken);

            List<MedicineDto> dtos = new List<MedicineDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicineDto>(x)));

            response.Data = dtos;
            response.IsSuccess = true;


            return response;
        }
    }
}
