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
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using Microsoft.AspNetCore.OutputCaching;

namespace MedicalCenters.API.Controllers.MedicalCenter
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCenterController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        const string CacheTage = "MedicalCenter_Cache";
        [HttpGet]
        [RequiresPermission(5)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy",Tags = [CacheTage])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenters(CancellationToken cancellationToken = default)
        {
            var query = new AllMedicalCentersQuery();
            BaseQueryResponse result = null;
            try
            {
                result = await mediator.Send(query, cancellationToken);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(4)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTage],VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalCenters(long Id, CancellationToken cancellationToken = default)
        {

            var query = new MedicalCenterQuery() { Id = Id };
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
                await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);
            }
            catch (Exception ex)
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
                await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);
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
            var command = new DeleteMedicalCenterCommand() { Id = id };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
                await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpGet("Wards/{MecicalCenterId}")]
        [RequiresPermission(10)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = ["MedicalWard_Cache"],VaryByQueryKeys = ["mecicalCenterId"])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenterWards(long mecicalCenterId)
        {
            var query = new AllMedicalCenterWardsQuery() { MedicalCenterId = mecicalCenterId };
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
    }
}
