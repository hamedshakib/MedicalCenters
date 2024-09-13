using MedicalCenters.Application.Responses;
using MedicalCenters.Identity.Classes;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Exceptions;
using MedicalCenters.Identity.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenters.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IAuthenticationRepository _authenticationRepository) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] LoginDto model)
        {
            long UserId;
            var userValidator = new AuthenticationLogin(_authenticationRepository);
            var ValidateUserresult = await userValidator.LoginValidateAsync(model);

            if (!ValidateUserresult.IsFindUser)
                throw new LoginFailedException(false);

            if (ValidateUserresult.LoginUser is null)
                throw new LoginFailedException(true);

            UserId = ValidateUserresult.LoginUser.UserId;

            var tokenCreator = new JWTTokenCreator(_authenticationRepository);

            var resultTokenDto = await tokenCreator.GenerateTokenDtoAsync(UserId, model.Username);

            var result = new BaseQueryResponse()
            {
                Errors = null,
                IsSuccess = true,
                Data = resultTokenDto
            };
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var tokenCreator = new JWTTokenCreator(_authenticationRepository);
            var resultTokenDto = await tokenCreator.GenerateTokenDtoAsync(tokenDto.AccessToken, tokenDto.RefreshToken);

            var result = new BaseQueryResponse()
            {
                Errors = null,
                IsSuccess = true,
                Data = resultTokenDto
            };
            return Ok(result);
        }

    }
}
