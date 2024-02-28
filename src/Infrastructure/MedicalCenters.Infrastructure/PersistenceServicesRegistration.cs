using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Infrastructure.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Persistence.Repositories.Identity;
using MedicalCenters.Persistence.Repositories.MedicalCenters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility.Configuration;

namespace MedicalCenters.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            string medicalCentersConnectionString, IdentityConnectionString;

            medicalCentersConnectionString = Environment.GetEnvironmentVariable("MedicalCentersConnectionString");
            if (string.IsNullOrEmpty(medicalCentersConnectionString))
            {
                medicalCentersConnectionString = Configuration.GetAppSettingJson()
                                                  .GetConnectionString("MedicalCentersConnectionString");
            }

            IdentityConnectionString = Environment.GetEnvironmentVariable("IdentityConnectionString");
            if (string.IsNullOrEmpty(IdentityConnectionString))
            {
                IdentityConnectionString = Configuration.GetAppSettingJson()
                                                  .GetConnectionString("IdentityConnectionString");
            }


            services.AddDbContext<MedicalCentersDBContext>(options =>
                                        options.UseSqlServer(medicalCentersConnectionString, x => x.UseNetTopologySuite()));
            services.AddDbContext<IdentityDBContext>(options =>
                            options.UseSqlServer(IdentityConnectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IMedicalCentersUnitOfWork, MedicalCentersUnitOfWork>();
            services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();

            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
            services.AddScoped<IAuthenticationRepository, AthenticationRepository>();
            return services;
        }
    }
}
