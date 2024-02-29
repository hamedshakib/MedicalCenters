using MediatR;
using MedicalCenters.API.ErrorHelper;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
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
    public class MedicalWardController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        const string CacheTage = "MedicalWard_Cache";

        [HttpGet("{id}")]
        [RequiresPermission(9)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTage])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalWard(long Id, CancellationToken cancellationToken = default)
        {
            var query = new MedicalWardQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(6)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicalWard([FromBody] CreateMedicalWardDto newMedicalWard, CancellationToken cancellationToken = default)
        {
            var command = new CreateMedicalWardCommand() { CreateMedicalWardDto = newMedicalWard };
            BaseValuedCommandResponse result = null;

            result = await mediator.Send(command, cancellationToken);
            await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut]
        [RequiresPermission(7)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalWard([FromBody] MedicalWardDto MedicalWard)
        {
            var command = new UpdateMedicalWardCommand() { MedicalWardDto = MedicalWard };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(8)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalWard(long id)
        {
            var command = new DeleteMedicalWardCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);

            return Ok(result);
        }
    }
}
