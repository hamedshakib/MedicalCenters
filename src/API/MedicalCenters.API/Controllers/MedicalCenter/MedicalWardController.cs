using MediatR;
using MedicalCenters.API.Constants;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.MedicalWard.Commands;
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
    public class MedicalWardController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {

        [HttpGet("{id}")]
        [RequiresPermission(PermissionEnum.SeeMedicalWardInfo)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.MedicalWard])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalWard(long Id, CancellationToken cancellationToken = default)
        {
            var query = new MedicalWardQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddMedicalWard)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicalWard([FromBody] MedicalWardDto newMedicalWard, CancellationToken cancellationToken = default)
        {
            var command = new CreateMedicalWardCommand() { MedicalWardDto = newMedicalWard };
            BaseValuedCommandResponse result = null;

            result = await mediator.Send(command, cancellationToken);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalWard, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.EditMedicalWard)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalWard([FromRoute] int id, [FromBody] MedicalWardDto MedicalWard)
        {
            var command = new UpdateMedicalWardCommand() { Id=id,MedicalWardDto = MedicalWard };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalWard, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.DeleteMedicalWard)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalWard(long id)
        {
            var command = new DeleteMedicalWardCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.MedicalWard, CancellationToken.None);

            return Ok(result);
        }
    }
}
