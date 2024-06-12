using MediatR;
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
            BaseQueryResponse result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(PermissionEnum.SeeMedicalCenterInfo)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalCenter], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalCenters(int Id, CancellationToken cancellationToken = default)
        {

            var query = new MedicalCenterQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddMedicalCenter)]
        public async Task<ActionResult<BaseValuedCommandResponse<int>>> AddMedicalCenter([FromBody] MedicalCenterDto newMedicalCenter)
        {
            var command = new CreateMedicalCenterCommand() { MedicalCenterDto = newMedicalCenter };
            BaseValuedCommandResponse<int> result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.EditMedicalCenter)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalCenter([FromRoute] int id, [FromBody] MedicalCenterDto medicalCenter)
        {
            var command = new UpdateMedicalCenterCommand() { Id=id,MedicalCenterDto = medicalCenter };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.DeleteMedicalCenter)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalCenter(int id)
        {
            var command = new DeleteMedicalCenterCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("Wards/{MecicalCenterId}")]
        [RequiresPermission(PermissionEnum.SeeAllMedicalCenterWardsInfos)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalWard], VaryByQueryKeys = ["mecicalCenterId"])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenterWards(int mecicalCenterId)
        {
            var query = new AllMedicalCenterWardsQuery() { MedicalCenterId = mecicalCenterId };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
