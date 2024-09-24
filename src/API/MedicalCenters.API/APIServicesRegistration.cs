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
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            services.AddOpenTelemetry()
                .WithMetrics(opt =>
                {
                    opt.ConfigureResource(n => ResourceBuilder.CreateDefault().AddService(assemblyName))
                        .AddAspNetCoreInstrumentation()
                        .AddRuntimeInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddProcessInstrumentation()
                        .AddPrometheusExporter();
                })
                .WithTracing(tracerProviderBuilder =>
                {
                    tracerProviderBuilder
                        .ConfigureResource(n => ResourceBuilder.CreateDefault().AddService(assemblyName))
                        .AddAspNetCoreInstrumentation(netCoreOption =>
                        {
                            netCoreOption.Filter = (httpContext) => !httpContext.Request.Path.StartsWithSegments("/metrics");
                            netCoreOption.Filter = (httpContext) => !httpContext.Request.Path.StartsWithSegments("/health");
                        })
                        .AddHttpClientInstrumentation(httpOption =>
                        {
                            httpOption.FilterHttpRequestMessage = httpRequestMessage =>
                                httpRequestMessage.RequestUri?.PathAndQuery != "/health";

                            httpOption.FilterHttpRequestMessage = httpRequestMessage =>
                                httpRequestMessage.RequestUri?.PathAndQuery != "/metrics";
                        })
                        .AddOtlpExporter(otlpOptions =>
                        {
                            otlpOptions.Endpoint = new Uri(configuration["Otlp:Endpoint"]);
                            otlpOptions.Protocol = OtlpExportProtocol.Grpc;
                        });
                })
                .WithLogging();

            services.AddHealthChecks()
                .AddCheck(assemblyName, () => HealthCheckResult.Healthy(), tags: ["live"])
                .AddSqlServer(configuration.GetConnectionString("MedicalCentersConnectionString"), tags: ["ready", "MedicalCentersDb", "sql-server", "db", "database"],name: "medicalCentersDb")
                .AddSqlServer(configuration.GetConnectionString("IdentityConnectionString"), tags: ["ready", "IdentityDb", "sql-server", "db", "database"], name: "identityDb")
                .AddRedis(configuration.GetConnectionString("RedisConnectionString"), tags: ["ready", "redis", "cache"]);

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
