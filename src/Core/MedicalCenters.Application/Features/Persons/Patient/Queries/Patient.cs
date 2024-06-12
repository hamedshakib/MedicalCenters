using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Persons.Patient.Queries
{
    internal class PatientQueryHandler(IPatientRepository PatientRepository, IMapper mapper) : IRequestHandler<PatientQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(PatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await PatientRepository.Get(request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException(Domain.Entities.Persons.Patient.EntityTitle, request.Id.ToString());
            }

            var dto = mapper.Map<PatientDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }

    public record class PatientQuery : IRequest<BaseQueryResponse>
    {
        public long Id { get; set; }
    }
}
