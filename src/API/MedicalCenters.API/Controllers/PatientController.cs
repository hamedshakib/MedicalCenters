using MediatR;
using MedicalCenters.API.Constants;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Persons.Patient.Commands;
using MedicalCenters.Application.Features.Persons.Patient.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Attributes;
using MedicalCenters.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        [HttpGet("{id}")]
        [RequiresPermission(PermissionEnum.SeeDotorInfo)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Patient], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetPatient(long Id, CancellationToken cancellationToken = default)
        {
            var query = new PatientQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddPatient)]
        public async Task<ActionResult<BaseValuedCommandResponse<long>>> AddPatient([FromBody] PatientDto newPatient)
        {
            var command = new CreatePatientCommand() { PatientDto = newPatient };
            BaseValuedCommandResponse<long> result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.Patient, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.EditPatient)]
        public async Task<ActionResult<BaseResponse>> UpdatePatient([FromRoute] long id, [FromBody] PatientDto Patient)
        {
            var command = new UpdatePatientCommand() { Id = id, PatientDto = Patient };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.Patient, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.DeletePatient)]
        public async Task<ActionResult<BaseResponse>> DeletePatient(long id)
        {
            var command = new DeletePatientCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTags.Patient, CancellationToken.None);

            return Ok(result);
        }
    }
}
