using MediatR;
using MedicalCenters.API.Constants;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Features.Medicine.Queries;
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
    public class MedicineController(IMediator mediator, IOutputCacheStore cacheStore) : ControllerBase
    {

        [HttpGet("MedicineType/{medicineTypeId}")]
        [RequiresPermission(PermissionEnum.SeeAllMedicineTypeMedicinesInfos)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Medicine], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicineTypeMedicines([FromRoute] int medicineTypeId, CancellationToken cancellationToken = default)
        {
            var query = new AllMedicineTypeMedicinesQuery() { MedicineTypeId = medicineTypeId };
            BaseQueryResponse? result = null;

            result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(PermissionEnum.SeeMedicines)]
        [OutputCache(PolicyName = "OutputCacheWithAuthPolicy", Tags = [CacheTags.Medicine], VaryByQueryKeys = ["Id"])]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicine([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new MedicineQuery() { Id = id };
            BaseQueryResponse? result = null;

            result = await mediator.Send(query,cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(PermissionEnum.AddMedicine)]
        public async Task<ActionResult<BaseValuedCommandResponse<int>>> AddMedicine([FromBody] MedicineDto newMedicine)
        {
            var command = new CreateMedicineCommand() { MedicineDto = newMedicine };
            BaseValuedCommandResponse<int>? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.Medicine, CancellationToken.None);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [RequiresPermission(PermissionEnum.EditMedicine)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicine([FromRoute] int id,[FromBody] MedicineDto medicine)
        {
            var command = new UpdateMedicineCommand() { Id= id,MedicineDto = medicine };
            BaseResponse? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.Medicine, CancellationToken.None);

            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(PermissionEnum.DeleteMedicine)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicine([FromRoute] int id)
        {
            var command = new DeleteMedicineCommand() { Id = id };
            BaseResponse? result = null;

            result = await mediator.Send(command,CancellationToken.None);
            await cacheStore.EvictByTagAsync(CacheTags.Medicine, CancellationToken.None);

            return Ok(result);
        }
    }
}
