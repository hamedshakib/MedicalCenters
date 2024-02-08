using AutoMapper;
using MediatR;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.Exceptions;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Validates;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalCenter.Handlers.Commands
{
    internal class UpdateMedicalCenterCommandHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<UpdateMedicalCenterCommand, BaseResponse>
    {
        public async Task<BaseResponse> Handle(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var medicalCenter=await unitOfWork.MedicalCenterRepository.Get(command.MedicalCenterDto.Id);
                if (medicalCenter is null)
                {
                    string Object= "مرکز درمانی" + command.MedicalCenterDto.Id.ToString();
                    throw new NotFoundException(Object);
                }

                mapper.Map(command.MedicalCenterDto, medicalCenter);

                await unitOfWork.MedicalCenterRepository.Update(medicalCenter);
                await unitOfWork.Save();

                response.IsSusses = true;
            }
            catch(ApplicationException ex)
            {
                response.IsSusses = false;
                response.Errors ??= new List<ErrorResponse>();
                response.Errors.Add(new ErrorResponse(2000, ex.Message));
            }
            catch(Exception ex)
            {
                response.IsSusses = false;
                response.Errors ??= new List<ErrorResponse>();
                response.Errors.Add(new ErrorResponse(-1, ex.Message));
            }


            return response;
        }
    }
}
