using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.Medicine.Commands
{
    internal class DeleteMedicineCommandHandler(IMedicineRepository medicineRepository, [FromKeyedServices("medicalCenters")] IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteMedicineCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(DeleteMedicineCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            if(!await medicineRepository.Exist((int)command.Id))
            {
                throw new NotFoundException("دارو", command.Id.ToString());
            }

            await medicineRepository.Delete((int)command.Id);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;

            return response;
        }
    }

    public class DeleteMedicineCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
