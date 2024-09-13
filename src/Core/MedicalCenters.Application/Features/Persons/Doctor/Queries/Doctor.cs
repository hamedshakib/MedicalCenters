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

namespace MedicalCenters.Application.Features.Persons.Doctor.Queries
{
    internal class DoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper) : IRequestHandler<DoctorQuery, BaseQueryResponse>
    {
        public async Task<BaseQueryResponse> Handle(DoctorQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResponse();
            cancellationToken.ThrowIfCancellationRequested();
            var result = await doctorRepository.GetAsync(request.Id, cancellationToken);
            if (result == null)
            {
                throw new NotFoundException(Domain.Entities.Persons.Staffs.Doctor.EntityTitle, request.Id.ToString());
            }

            var dto = mapper.Map<DoctorDto>(result);

            response.Data = dto;
            response.IsSuccess = true;

            return response;
        }
    }

    public record class DoctorQuery : IRequest<BaseQueryResponse>
    {
        public int Id { get; set; }
    }
}
