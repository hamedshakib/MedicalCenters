using MedicalCenters.Application;
using MedicalCenters.Persistence;
namespace MedicalCenters.API
{
    public static class APIServicesRegistration
    {
        public static IServiceCollection ConfigureAPIServices(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.ConfigureApplicationServices();
            services.ConfigurePersistenceServices();
            return services;
        }
    }
}
