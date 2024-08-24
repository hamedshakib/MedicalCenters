using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace MedicalCenters.Cache
{
    public class RedisDatabaseProvider(IConfiguration configuration)
    {
        public IDatabase GetDatabase()
        {
            string ConnectionString = configuration.GetConnectionString("RedisConnectionString");
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConnectionString);
            IDatabase db = redis.GetDatabase();
            return db;
        }
    }
}
