﻿using MedicalCenters.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MedicalCenters.Application.DTOs.MedicalCenter;

namespace MedicalCenters.Application.Features.MedicalCenter.Requests.Commands
{
    public record CreateMedicalCenterCommand : IRequest<BaseValuedCommandResponse>
    {
        public CreateMedicalCenterDto CreateMedicalCenterDto { get; set; }
    }
}