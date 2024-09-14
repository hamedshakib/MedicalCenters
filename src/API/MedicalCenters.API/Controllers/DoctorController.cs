using MediatR;
using MedicalCenters.API.Constants;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Features.Medicine.Queries;
using MedicalCenters.Application.Features.Persons.Doctor.Commands;
using MedicalCenters.Application.Features.Persons.Doctor.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Attributes;
using MedicalCenters.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet("{id}")]
        [RequiresPermission(PermissionEnum.SeeDotorInfo)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Doctor], VaryByQueryKeys = ["id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetDoctor([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new DoctorQuery() { Id = id };
            BaseQueryResponse? result = null;

            result = await mediator.Send(query,cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddDoctor)]
        public async Task<ActionResult<BaseValuedCommandResponse<int>>> AddDoctor([FromBody] DoctorDto newDoctor)
        {
            var command = new CreateDoctorCommand() { DoctorDto = newDoctor };
            BaseValuedCommandResponse<int>? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.Doctor, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.EditDoctor)]
        public async Task<ActionResult<BaseResponse>> UpdateDoctor([FromRoute] int id, [FromBody] DoctorDto doctor)
        {
            var command = new UpdateDoctorCommand() { Id = id, DoctorDto = doctor };
            BaseResponse? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.Doctor, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.DeleteDoctor)]
        public async Task<ActionResult<BaseResponse>> DeleteDoctor([FromRoute] int id)
        {
            var command = new DeleteDoctorCommand() { Id = id };
            BaseResponse? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.Doctor, CancellationToken.None);

            return Ok(result);
        }
    }
}
