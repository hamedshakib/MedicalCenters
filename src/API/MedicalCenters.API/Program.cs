using MedicalCenters.API;
using MedicalCenters.Identity.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureAPIServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
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
