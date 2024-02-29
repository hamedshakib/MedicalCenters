using MedicalCenters.API.ErrorHelper;
using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Classes;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Exceptions;
using MedicalCenters.Identity.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IIdentityUnitOfWork unitOfWork) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] LoginDto model)
        {
            long UserId;
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
                new Claim(JwtRegisteredClaimNames.Sid , UserId.ToString()),
            };

            var jwt = JWTTokenCreator.GetJWTToken(claims);
            var result = new BaseQueryResponse()
            {
                Errors = null,
                IsSuccess = true,
                Data = jwt
            };
            return Ok(result);
        }
    }
}
