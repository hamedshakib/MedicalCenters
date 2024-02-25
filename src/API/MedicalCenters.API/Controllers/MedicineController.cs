using MediatR;
using MedicalCenters.API.ErrorHelper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Commands;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Features.Medicine.Requests.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Entities.Medicines;
using MedicalCenters.Identity.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController(IMediator mediator) : ControllerBase
    {
        [HttpGet("MedicineType/{MedicineTypeId}")]
        [RequiresPermission(15)]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicineTypeMedicines(long MedicineTypeId, CancellationToken cancellationToken = default)
        {
            var query = new AllMedicineTypeMedicinesQuery() { MedicineTypeId = MedicineTypeId };
            BaseQueryResponse result = null;
            try
            {
                result = await mediator.Send(query, cancellationToken);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [RequiresPermission(14)]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicine(long Id, CancellationToken cancellationToken = default)
        {
            var query = new MedicineQuery() { Id = Id };
            BaseQueryResponse result = null;
            try
            {
                result = await mediator.Send(query);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpPost]
        [RequiresPermission(11)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicine([FromBody] CreateMedicineDto newMedicine)
        {
            var command = new CreateMedicineCommand() { CreateMedicineDto = newMedicine };
            BaseValuedCommandResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }

        [HttpPut]
        [RequiresPermission(12)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicine([FromBody] MedicineDto medicine)
        {
            var command = new UpdateMedicineCommand() { MedicineDto = medicine };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);

        }

        [HttpDelete("{id}")]
        [RequiresPermission(13)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicine(long id)
        {
            var command = new DeleteMedicineCommand() { Id = id };
            BaseResponse result = null;
            try
            {
                result = await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
            return Ok(result);
        }
    }
}
