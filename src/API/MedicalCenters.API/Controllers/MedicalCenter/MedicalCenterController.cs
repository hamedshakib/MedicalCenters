using MediatR;
using MedicalCenters.API.Constants;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Attributes;
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
        [RequiresPermission(5)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalCenter])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenters(CancellationToken cancellationToken = default)
        {
            var query = new AllMedicalCentersQuery();
            BaseQueryResponse result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(4)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalCenter], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalCenters(long Id, CancellationToken cancellationToken = default)
        {

            var query = new MedicalCenterQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(1)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicalCenter([FromBody] CreateMedicalCenterDto newMedicalCenter)
        {
            var command = new CreateMedicalCenterCommand() { CreateMedicalCenterDto = newMedicalCenter };
            BaseValuedCommandResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut]
        [RequiresPermission(2)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalCenter([FromBody] MedicalCenterDto medicalCenter)
        {
            var command = new UpdateMedicalCenterCommand() { MedicalCenterDto = medicalCenter };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(3)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalCenter(long id)
        {
            var command = new DeleteMedicalCenterCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalCenter, CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("Wards/{MecicalCenterId}")]
        [RequiresPermission(10)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalWard], VaryByQueryKeys = ["mecicalCenterId"])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenterWards(long mecicalCenterId)
        {
            var query = new AllMedicalCenterWardsQuery() { MedicalCenterId = mecicalCenterId };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);

            return Ok(result);
        }
    }
}
