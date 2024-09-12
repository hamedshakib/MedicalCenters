using MedicalCenters.API.ErrorHelper;
using MedicalCenters.API.Policies;
using MedicalCenters.Application;
using MedicalCenters.Cache;
using MedicalCenters.Identity;
using MedicalCenters.Persistence;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCenters.API
{
    public static class APIServicesRegistration
    {
        public static IServiceCollection ConfigureAPIServices(this IServiceCollection services,IConfiguration configuration)
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
            services.ConfigureCacheServices(configuration);
            services.ConfigureApplicationServices(configuration);
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureIdentityServices(configuration);

            return services;
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "Api document",
                    Title = "Api Document",
                    Version = $"v{version}"
                });


                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put ONLY your JWT Bearer token",

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
        }
    }
}
