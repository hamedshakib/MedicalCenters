using MedicalCenters.Identity.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MedicalCenters.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services)
        {

            services.AddTransient(provider =>  new OverLimitRequestChecker(provider.GetService<IDatabase>()));

            services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = PreparerTokenValidationParameters.GetTokenValidationParameters();
            });

            services.AddAuthorization();

            return services;
        }
    }
}
