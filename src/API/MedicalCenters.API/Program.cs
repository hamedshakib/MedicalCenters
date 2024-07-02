using MedicalCenters.API;
using MedicalCenters.Identity.Classes;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Utility.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureAPIServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(Configuration.GetAppSettingJson())
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .MinimumLevel.Override("System", LogEventLevel.Error)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(Configuration.GetAppSettingJson())
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
    Update-Database -Context MedicalCentersDBContext


    Add-Migration InitialCreate -Context IdentityDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
    Optimize-DbContext -OutputDir CompiledModels/Identity -Context IdentityDBContext -Project MedicalCenters.Persistence -StartupProject MedicalCenters.API
    Update-Database -Context IdentityDBContext

 */