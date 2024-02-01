﻿using Microsoft.Extensions.DependencyInjection;
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

namespace MedicalCenters.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();
            var medicalCentersConnectionString = configuration.GetConnectionString("MedicalCentersConnectionString");
            services.AddDbContext<MedicalCentersDBContext>(options => options.UseSqlServer(medicalCentersConnectionString));
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMedicalCenterRepository, MedicalCenterRepository>();
            return services;
        }
    }
}
