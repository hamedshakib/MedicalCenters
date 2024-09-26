using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MedicalCenters.Cache
{
    public static class CacheServicesRegistration
    {
        public static IServiceCollection ConfigureCacheServices(this IServiceCollection services,IConfiguration configuration)
        {
            var redisConnection = new RedisConnectionProvider(configuration).GetConnection();
            var redisDatabase=redisConnection.GetDatabase();
            services.AddTransient<IDatabase>(provider => redisDatabase);
            services.AddSingleton<IMasterCacheProvider>(new MasterCacheProvider(redisConnection));

            return services;
        }
    }
}
