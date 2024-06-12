using MedicalCenters.API.ErrorHelper;
using MedicalCenters.API.Policies;
using MedicalCenters.Application;
using MedicalCenters.Cache;
using MedicalCenters.Identity;
using MedicalCenters.Persistence;
using Microsoft.OpenApi.Models;
namespace MedicalCenters.API
{
    public static class APIServicesRegistration
    {
        public static IServiceCollection ConfigureAPIServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddOutputCache(options =>
            {
                options.AddBasePolicy(builder => builder.Cache());
                options.AddPolicy("OutputCacheWithAuthPolicy", OutputCacheWithAuthPolicy.Instance);
                options.UseCaseSensitivePaths = false;
                options.DefaultExpirationTimeSpan = TimeSpan.FromDays(1);
            });

            services.AddExceptionHandler<ExceptionHandler>();
            services.AddProblemDetails();

            services.AddSwagger();

            services.AddEndpointsApiExplorer();
            services.ConfigureApplicationServices();
            services.ConfigurePersistenceServices();
            services.ConfigureIdentityServices();
            services.ConfigureCacheServices();

            return services;
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer Token", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer token')",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
