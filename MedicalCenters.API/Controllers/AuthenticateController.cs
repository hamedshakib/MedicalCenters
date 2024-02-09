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
        public void Token([FromBody] LoginModel model)
        {
            //Check If model Data is valid


            var claims = new List<Claim>()
            { 
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName ,model.Username),
            };

            var jwt=JWTTokenCreator.GetJWTToken(claims);
            Ok(jwt);

        }
    }
}
