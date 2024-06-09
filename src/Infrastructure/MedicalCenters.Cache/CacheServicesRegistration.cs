using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Cache
{
    public static class CacheServicesRegistration
    {
        public static IServiceCollection ConfigureCacheServices(this IServiceCollection services)
        {
            services.AddSingleton<IMasterCacheProvider>(new MasterCacheProvider(RedisDatabase.Database));

            return services;
        }
    }
}
