using MediatR;
using MedicalCenters.API.ErrorHelper;
using MedicalCenters.Application.DTOs.MedicalCenter;
using MedicalCenters.Application.DTOs.MedicalWard;
using MedicalCenters.Application.Features.MedicalWard.Requests.Commands;
using MedicalCenters.Application.Features.MedicalWard.Requests.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalWardController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [RequiresPermission(10)]
        public async Task<ActionResult<BaseQueryResponse>> GetAllMedicalCenterWards(long mecicalCenterId)
        {
            var query = new AllMedicalCenterWardsQuery() { MedicalCenterId = mecicalCenterId };
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

        [Authorize]
        [HttpGet("{id}")]
        [RequiresPermission(9)]
        public async Task<ActionResult<BaseQueryResponse>> GetMedicalWard(long Id)
        {
            var query = new MedicalWardQuery() { Id = Id };
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
        [RequiresPermission(6)]
        public async Task<ActionResult<BaseValuedCommandResponse>> AddMedicalWard([FromBody] CreateMedicalWardDto newMedicalWard)
        {
            var command = new CreateMedicalWardCommand() { CreateMedicalWardDto = newMedicalWard };
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
        [RequiresPermission(7)]
        public async Task<ActionResult<BaseResponse>> UpdateMedicalWard([FromBody] MedicalWardDto MedicalWard)
        {
            var command = new UpdateMedicalWardCommand() { MedicalWardDto = MedicalWard };
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
        [RequiresPermission(8)]
        public async Task<ActionResult<BaseResponse>> DeleteMedicalWard(long id)
        {
            var command = new DeleteMedicalWardCommand() { Id = id };
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
