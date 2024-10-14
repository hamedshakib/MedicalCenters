using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace MedicalCenters.Cache
{
    public class RedisConnectionProvider(IConfiguration configuration)
    {
        private readonly CancellationTokenSource _resetTokenSource = new CancellationTokenSource();
        public ConnectionMultiplexer GetConnection()
        {
            string ConnectionString = configuration.GetConnectionString("RedisConnectionString");
            ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(ConnectionString);

            return redisConnection;
        }
    }
}
