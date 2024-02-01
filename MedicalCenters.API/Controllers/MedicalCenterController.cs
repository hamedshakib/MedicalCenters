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
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicalCenter([FromBody] CreateMedicalCenterDto newMedicalCenter)
        {
            var command = new CreateMedicalCenterCommand() { CreateMedicalCenterDto = newMedicalCenter };
            BaseValuedCommandResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (ValidationException ex)
            {
                var tempRes = new BaseValuedCommandResponse()
                {
                    IsSusses = false,
                    Id = null,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                var tempRes = new BaseValuedCommandResponse()
                {
                    IsSusses = false,
                    Id = null,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest(tempRes);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalCenter([FromBody] MedicalCenterDto medicalCenter)
        {
            var command = new UpdateMedicalCenterCommand() { MedicalCenterDto = medicalCenter };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (ValidationException ex)
            {
                var tempRes = new BaseResponse()
                {
                    IsSusses = false,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                var tempRes = new BaseResponse()
                {
                    IsSusses = false,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest(tempRes);
            }
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalCenter(long id)
        {
            var command = new DeleteMedicalCenterCommand() { Id=id };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (ValidationException ex)
            {
                var tempRes = new BaseResponse()
                {
                    IsSusses = false,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest();
            }
            catch (Exception ex)
            {
                var tempRes = new BaseResponse()
                {
                    IsSusses = false,
                    Errors = ex.ErrorsResponse()
                };
                return BadRequest(tempRes);
            }
            return Ok(result);
        }
    }
}
