using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Infrastructure.Repositories;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.Extensions.Configuration;
using Utility.Configuration;
using MedicalCenters.Identity.Contracts;
using MedicalCenters.Persistence.Repositories.Identity;
using MedicalCenters.Persistence.Repositories.MedicalCenters;
using MedicalCenters.Persistence.DBContexts;

namespace MedicalCenters.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            string medicalCentersConnectionString, IdentityConnectionString;
            
            medicalCentersConnectionString = Environment.GetEnvironmentVariable("MedicalCentersConnectionString");
            if(string.IsNullOrEmpty(medicalCentersConnectionString)) 
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

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IMedicalCentersUnitOfWork, MedicalCentersUnitOfWork>();
            services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();

            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
            services.AddScoped<IAthenticationRepository, AthenticationRepository>();
            return services;
        }
    }
}
