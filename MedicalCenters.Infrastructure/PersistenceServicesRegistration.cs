using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Persistence.Repositories;
using MedicalCenters.Infrastructure.Repositories;

namespace MedicalCenters.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();
            return services;
        }
    }
}
