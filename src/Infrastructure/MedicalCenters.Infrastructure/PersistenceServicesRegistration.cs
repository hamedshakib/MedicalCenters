using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Domain.Contracts;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Persistence.DBContexts;
using MedicalCenters.Infrastructure.Repositories;
using MedicalCenters.Persistence.Repositories.Identity;
using MedicalCenters.Persistence.Repositories.MedicalCenters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCenters.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            string medicalCentersConnectionString, IdentityConnectionString;

            medicalCentersConnectionString = Environment.GetEnvironmentVariable("MedicalCentersConnectionString");
            if (string.IsNullOrEmpty(medicalCentersConnectionString))
            {
                medicalCentersConnectionString = configuration.GetConnectionString("MedicalCentersConnectionString");
            }

            IdentityConnectionString = Environment.GetEnvironmentVariable("IdentityConnectionString");
            if (string.IsNullOrEmpty(IdentityConnectionString))
            {
                IdentityConnectionString = configuration.GetConnectionString("IdentityConnectionString");
            }


            services.AddDbContext<MedicalCentersDBContext>(options =>
            {
                options.UseSqlServer(medicalCentersConnectionString, x => x.UseNetTopologySuite());
                //options.UseModel(MedicalCentersDBContextModel.Instance);
            });

            services.AddDbContext<IdentityDBContext>(options => 
            {
                options.UseSqlServer(IdentityConnectionString);
                //options.UseModel(IdentityDBContextModel.Instance);
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddKeyedScoped<IUnitOfWork, IdentityUnitOfWork>("identity");
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

            services.AddKeyedScoped<IUnitOfWork, MedicalCentersUnitOfWork>("medicalCenters");
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();
            services.AddScoped<IMedicalWardRepository, MedicalWardRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
