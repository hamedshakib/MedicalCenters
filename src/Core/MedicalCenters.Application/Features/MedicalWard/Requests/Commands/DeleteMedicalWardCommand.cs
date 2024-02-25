using MediatR;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.Features.MedicalWard.Requests.Commands
{
    public record DeleteMedicalWardCommand : IRequest<BaseResponse>
    {
        public long Id { get; set; }
    }
}
