using MedicalCenters.API.Policies;
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

            services.AddOutputCache(options =>
            {
                options.AddBasePolicy(builder => builder.Cache());
                options.AddPolicy("OutputCacheWithAuthPolicy", OutputCacheWithAuthPolicy.Instance);
                options.UseCaseSensitivePaths = false;
                options.DefaultExpirationTimeSpan = TimeSpan.FromDays(1);
            });

            services.AddEndpointsApiExplorer();
            services.ConfigureApplicationServices();
            services.ConfigurePersistenceServices();
            services.ConfigureIdentityServices();

            return services;
        }
    }
}
