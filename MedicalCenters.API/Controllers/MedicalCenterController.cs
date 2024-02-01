using FluentValidation.Results;
using MediatR;
using MedicalCenters.API.Utility.Extentions;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCenterController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> AddMedicalCenter([FromBody] CreateMedicalCenterDto newMedicalCenter)
        {
            var command = new CreateMedicalCenterCommand(){ CreateMedicalCenterDto=newMedicalCenter };
            Task<BaseCommandResponse> result = null;
            try
            {
                result = mediator.Send(command);
            }
            catch(ValidationException ex)
            {

                var tempRes = new BaseCommandResponse()
                {
                    IsSusses = false,
                    Id = null,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest();
            }
            catch (Exception ex) 
            {
                var tempRes =new BaseCommandResponse()
                {
                    IsSusses = false,
                    Id = null,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest(tempRes);
            }

            if (result is not null)
                return Ok(result);
            else 
                return BadRequest();
        }
    }
}
