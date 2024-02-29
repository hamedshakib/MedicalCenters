using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Utility.Configuration;

namespace MedicalCenters.Cache
{
    public class RedisDatabase
    {
        private static IDatabase instance;
        public static IDatabase Database {
            get
            {
                if (instance is null)
                    instance = GetDatabase();
                return instance;
            } 
        }
        private RedisDatabase()
        {
            
        }

        private static IDatabase GetDatabase()
        {
            string ConnectionString = Configuration.GetAppSettingJson()
                                                  .GetConnectionString("RedisConnectionString");
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConnectionString);
            IDatabase db = redis.GetDatabase();
            return db;
        }
    }
}
