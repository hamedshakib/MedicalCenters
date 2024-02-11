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
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.RegularExpressions;
using System;
using MedicalCenters.API.ErrorHelper;
using Microsoft.AspNetCore.Authorization;
using MedicalCenters.Identity.Attributes;
using MedicalCenters.Identity.Contracts;

namespace MedicalCenters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCenterController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [RequiresPermission(5)]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenters()
        {
            var query = new AllMedicalCentersQuery();
            BaseQueryResponse result = null;
            try
            {
                result = await mediator.Send(query);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        [RequiresPermission(4)]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalCenters(long Id)
        {
            var query = new MedicalCenterQuery() {Id=Id };
            BaseQueryResponse result = null;
            try
            {
                result = await mediator.Send(query);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(1)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicalCenter([FromBody] CreateMedicalCenterDto newMedicalCenter)
        {
            var command = new CreateMedicalCenterCommand() { CreateMedicalCenterDto = newMedicalCenter };
            BaseValuedCommandResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch(Exception ex) 
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpPut]
        [RequiresPermission(2)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalCenter([FromBody] MedicalCenterDto medicalCenter)
        {
            var command = new UpdateMedicalCenterCommand() { MedicalCenterDto = medicalCenter };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(3)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalCenter(long id)
        {
            var command = new DeleteMedicalCenterCommand() { Id=id };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }
    }
}
