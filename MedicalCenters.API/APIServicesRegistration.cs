using MedicalCenters.Application;
using MedicalCenters.Identity;
using MedicalCenters.Persistence;
namespace MedicalCenters.API
{
    public static class APIServicesRegistration
    {
        public static IServiceCollection ConfigureAPIServices(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.ConfigureApplicationServices();
            services.ConfigurePersistenceServices();
            services.ConfigureIdentityServices();

            return services;
        }
    }
}
