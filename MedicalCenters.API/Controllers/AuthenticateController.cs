using MedicalCenters.Identity.Classes;
using MedicalCenters.Identity.Model;
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
    public class AuthenticateController : ControllerBase
    {
        //[AllowAnonymous]
        //[HttpPost("login")]
        //public void Login([FromBody] LoginModel model)
        //{
            
        //}

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Token([FromBody] LoginModel model)
        {
            //Check If model Data is valid
            long UserId = 1;




            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName ,model.Username),
                new Claim(JwtRegisteredClaimNames.Sid , UserId.ToString())
            };

            var jwt = JWTTokenCreator.GetJWTToken(claims);
            return Ok(jwt);
        }
    }
}
