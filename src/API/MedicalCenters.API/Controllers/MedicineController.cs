using MediatR;
using MedicalCenters.API.ErrorHelper;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Features.Medicine.Requests.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {
        const string CacheTage = "Medicine_Cache";

        [HttpGet("MedicineType/{MedicineTypeId}")]
        [RequiresPermission(15)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTage], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicineTypeMedicines(long MedicineTypeId, CancellationToken cancellationToken = default)
        {
            var query = new AllMedicineTypeMedicinesQuery() { MedicineTypeId = MedicineTypeId };
            BaseQueryResponse result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(14)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTage], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicine(long Id, CancellationToken cancellationToken = default)
        {
            var query = new MedicineQuery() { Id = Id };
            BaseQueryResponse result = null;

            result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(11)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicine([FromBody] CreateMedicineDto newMedicine)
        {
            var command = new CreateMedicineCommand() { CreateMedicineDto = newMedicine };
            BaseValuedCommandResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut]
        [RequiresPermission(12)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicine([FromBody] MedicineDto medicine)
        {
            var command = new UpdateMedicineCommand() { MedicineDto = medicine };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(13)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicine(long id)
        {
            var command = new DeleteMedicineCommand() { Id = id };
            BaseResponse result = null;

            result = await mediator.Send(command);
            await cacheStore.EvictByTagAsync(CacheTage, CancellationToken.None);

            return Ok(result);
        }
    }
}
