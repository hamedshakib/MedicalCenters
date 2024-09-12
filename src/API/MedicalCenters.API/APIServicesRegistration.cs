using MedicalCenters.API.ErrorHelper;
using MedicalCenters.API.Policies;
using MedicalCenters.Application;
using MedicalCenters.Cache;
using MedicalCenters.Identity;
using MedicalCenters.Persistence;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MedicalCenters.API
{
    public static class APIServicesRegistration
    {
        public static IServiceCollection ConfigureAPIServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                 {
                     var errors = context.ModelState
                         .Where(e => e.Value.Errors.Count > 0)
                         .Select(e => new
                         {
                             Field = e.Key,
                             Messages = e.Value.Errors.Select(err => err.ErrorMessage).ToArray()
                         }).ToArray();

                     var errorMessages = errors.SelectMany(e => e.Messages).ToList();

                     var result = new BaseResponse
                     {
                         IsSuccess = false,
                         Errors = new List<ErrorResponse>(errorMessages.Select(e => new ErrorResponse((int)ErrorEnums.Validation,e)))
                     };

                     return new BadRequestObjectResult(result);
                 };
            });

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

                options.SchemaFilter<DescriptionSchemaFilter>();

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put ONLY your JWT Bearer token",

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
