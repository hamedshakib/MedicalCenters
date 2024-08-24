using MedicalCenters.API;
using MedicalCenters.Identity.Classes;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Events;
using System.Reflection;
using Utility.Configuration;

var builder = WebApplication.CreateBuilder(args);


SetAppSettings(builder);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.ConfigureAPIServices();

var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
builder.Services.AddOpenTelemetry()
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
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter(otlpOptions =>
            {
                otlpOptions.Endpoint = new Uri(builder.Configuration["Otlp:Endpoint"]);
                otlpOptions.Protocol = OtlpExportProtocol.Grpc;
            });
    })
    .WithLogging();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(Configuration.GetAppSettingJson())
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .MinimumLevel.Override("System", LogEventLevel.Error)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(app.Configuration)
    .CreateLogger();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<RequestAcceptabilityMiddleware>();

app.UseOutputCache();

app.MapControllers();


app.Run();

/*
 * For create Migration,Optimize DbContext,Update Database

    Add-Migration InitialCreate -Context MedicalCentersDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
    Optimize-DbContext -OutputDir CompiledModels/MedicalCenters -Context MedicalCentersDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
    Update-Database -Context MedicalCentersDBContext -StartupProject MedicalCenters.API


    Add-Migration InitialCreate -Context IdentityDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
    Optimize-DbContext -OutputDir CompiledModels/Identity -Context IdentityDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
    Update-Database -Context IdentityDBContext -StartupProject MedicalCenters.API

 */


void SetAppSettings(WebApplicationBuilder builder)
{
    bool isInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

    if (isInDocker)
    {
        builder.Configuration.AddJsonFile("appsettings.Docker.json", false, true);
    }
    else if(builder.Environment.IsDevelopment())
    {
        builder.Configuration.AddJsonFile("appsettings.Development.json", false, true);
    }
    else if (builder.Environment.IsProduction())
    {
        builder.Configuration.AddJsonFile("appsettings.json", false, true);
    }


}