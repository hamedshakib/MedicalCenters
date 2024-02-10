using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Persistence.Repositories;
using MedicalCenters.Infrastructure.Repositories;
using MedicalCenters.Infrastructure.DBContexts;
using Microsoft.Extensions.Configuration;
using Utility.Configuration;

namespace MedicalCenters.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            var medicalCentersConnectionString = Configuration.GetAppSettingJson()
                                                              .GetConnectionString("MedicalCentersConnectionString");

            services.AddDbContext<MedicalCentersDBContext>(options => 
                                        options.UseSqlServer(medicalCentersConnectionString, x => x.UseNetTopologySuite()));
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IMedicalCentersUnitOfWork, MedicalCentersUnitOfWork>();
            services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();
            return services;
        }
    }
}
