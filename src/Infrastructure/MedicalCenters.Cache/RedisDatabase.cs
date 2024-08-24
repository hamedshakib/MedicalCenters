using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Utility.Configuration;

namespace MedicalCenters.Cache
{
    public class RedisDatabaseProvider(IConfiguration configuration)
    {
        public IDatabase GetDatabase()
        {
            string ConnectionString = configuration["ConnectionStrings:RedisConnectionString"];
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConnectionString);
            IDatabase db = redis.GetDatabase();
            return db;
        }
    }
}
