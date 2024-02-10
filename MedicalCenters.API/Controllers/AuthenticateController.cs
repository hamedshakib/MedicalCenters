using MediatR;
using MedicalCenters.API.ErrorHelper;
using MedicalCenters.Application.Features.MedicalCenter.Requests.Queries;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Classes;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Exceptions;
using MedicalCenters.Identity.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IIdentityUnitOfWork unitOfWork) : ControllerBase
    {
        //[AllowAnonymous]
        //[HttpPost("login")]
        //public void Login([FromBody] LoginModel model)
        //{
            
        //}

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] LoginDto model)
        {
            //string JWTToken= string.Empty;
            //BaseQueryResponse result = null;
            //try
            //{
            //    result = await mediator.Send(query);
            //}
            //catch (Exception ex)
            //{
            //    return ex.ToObjectResult();
            //}
            //return Ok(result);


            //Check If model Data is valid
            long UserId;
            try
            {
                var userValidator = new AuthenticationLogin(unitOfWork);
                var ValidateUserresult = await userValidator.LoginValidate(model);

                if (!ValidateUserresult.IsFindUser)
                    throw new LoginFailedException(false);

                if (ValidateUserresult.LoginUser is null)
                    throw new LoginFailedException(true);

                UserId = ValidateUserresult.LoginUser.UserId;

                var claims = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName ,model.Username),
                    new Claim(JwtRegisteredClaimNames.Sid , UserId.ToString())
                };

                var jwt = JWTTokenCreator.GetJWTToken(claims);
                var result = new BaseQueryResponse()
                {
                    Errors = null,
                    IsSusses = true,
                    Data = jwt
                };
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return ex.ToObjectResult();
            }
        }
    }
}
