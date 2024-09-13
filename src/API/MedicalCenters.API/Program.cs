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
using MedicalCenters.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

bool isInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
SetAppSettings(builder, isInDocker);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.ConfigureAPIServices(builder.Configuration);

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
    .ReadFrom.Configuration(builder.Configuration)
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

app.UseOpenTelemetryPrometheusScrapingEndpoint();

using (var scope = app.Services.CreateScope())
{
    if (isInDocker)
    {
        var identityDb = scope.ServiceProvider.GetRequiredService<IdentityDBContext>();
        if (identityDb.Database.GetPendingMigrations().Any())
        {
            identityDb.Database.Migrate();
        }


        var medicalCentersDB = scope.ServiceProvider.GetRequiredService<MedicalCentersDBContext>();
        if (medicalCentersDB.Database.GetPendingMigrations().Any())
        {
            medicalCentersDB.Database.Migrate();
        }
        medicalCentersDB.Database.Migrate();
    }
}


app.Run();














void SetAppSettings(WebApplicationBuilder builder,bool isInDocker = false)
{
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