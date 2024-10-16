﻿using MediatR;
using MedicalCenters.API.Constants;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalCenter.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Queries;
using MedicalCenters.Application.Features.MedicalWard.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Attributes;
using MedicalCenters.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace MedicalCenters.API.Controllers.MedicalCenter
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCenterController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet]
        [RequiresPermission(PermissionEnum.SeeAllMedicalCentersInfos)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalCenter])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenters(CancellationToken cancellationToken = default)
        {
            var query = new AllMedicalCentersQuery();
            BaseQueryResponse? result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(PermissionEnum.SeeMedicalCenterInfo)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalCenter], VaryByQueryKeys = ["id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalCenters([FromRoute] int id, CancellationToken cancellationToken = default)
        {

            var query = new MedicalCenterQuery() { Id = id };
            BaseQueryResponse? result = null;

            result = await mediator.Send(query,cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddMedicalCenter)]
        public async Task<ActionResult<BaseValuedCommandResponse<int>>> AddMedicalCenter([FromBody] MedicalCenterDto newMedicalCenter)
        {
            var command = new CreateMedicalCenterCommand() { MedicalCenterDto = newMedicalCenter };
            BaseValuedCommandResponse<int>? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.EditMedicalCenter)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalCenter([FromRoute] int id, [FromBody] MedicalCenterDto medicalCenter)
        {
            var command = new UpdateMedicalCenterCommand() { Id=id,MedicalCenterDto = medicalCenter };
            BaseResponse? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.DeleteMedicalCenter)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalCenter([FromRoute] int id)
        {
            var command = new DeleteMedicalCenterCommand() { Id = id };
            BaseResponse? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("Wards/{medicalCenterId}")]
        [RequiresPermission(PermissionEnum.SeeAllMedicalCenterWardsInfos)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalWard], VaryByQueryKeys = ["medicalCenterId"])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenterWards(int medicalCenterId)
        {
            var query = new AllMedicalCenterWardsQuery() { MedicalCenterId = medicalCenterId };
            BaseQueryResponse? result = null;

            result = await mediator.Send(query,CancellationToken.None);

            return Ok(result);
        }
    }
}
