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
        [RequiresPermission(PermissionEnum.AddMedicalCenter)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Doctor], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetDoctor(int Id, CancellationToken cancellationToken = default)
        {
            var query = new DoctorQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddMedicalCenter)]
        public async Task<ActionResult<BaseValuedCommandResponse<int>>> AddDoctor([FromBody] DoctorDto newDoctor)
        {
            var command = new CreateDoctorCommand() { DoctorDto = newDoctor };
            BaseValuedCommandResponse<int> result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.Doctor, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.AddMedicalCenter)]
        public async Task<ActionResult<BaseResponse>> UpdateDoctor([FromRoute] int id, [FromBody] DoctorDto doctor)
        {
            var command = new UpdateDoctorCommand() { Id = id, DoctorDto = doctor };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.Doctor, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.AddMedicalCenter)]
        public async Task<ActionResult<BaseResponse>> DeleteDoctor(int id)
        {
            var command = new DeleteDoctorCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.Doctor, CancellationToken.None);

            return Ok(result);
        }
    }
}
