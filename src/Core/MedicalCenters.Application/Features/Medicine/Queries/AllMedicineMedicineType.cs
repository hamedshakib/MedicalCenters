using AutoMapper;
using MediatR;
using MedicalCenters.Application.DTOs;
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
    internal class AllMedicineMedicineTypeQueryHanlder(IMedicineRepository medicineRepository, IMapper mapper) : IRequestHandler<AllMedicineTypeMedicinesQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(AllMedicineTypeMedicinesQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await medicineRepository.GetAllMedicineTypeMedicinesAsync(request.MedicineTypeId, cancellationToken);

            List<MedicineDto> dtos = new List<MedicineDto>();
            result.ToList().ForEach(x => dtos.Add(mapper.Map<MedicineDto>(x)));

            response.Data = dtos;
            response.IsSuccess = true;


            return response;
        }
    }

    public record class AllMedicineTypeMedicinesQuery : IRequest<BaseQueryResponse>
    {
        public int MedicineTypeId { get; set; }
    }
}
