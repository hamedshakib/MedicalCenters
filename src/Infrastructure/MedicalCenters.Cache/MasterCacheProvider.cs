using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Cache
{
    internal class MasterCacheProvider(IDatabase _database) : IMasterCacheProvider
    {
        public async Task<T?> GetAsync<T>(string cacheKey)
        {
            try
            {
                var value = await _database.StringGetAsync(cacheKey);

                if (value.IsNull || !value.HasValue)
                    return default(T);

                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task SetAsync<T>(string cacheKey, T value, TimeSpan expirationTime)
        {
            try
            {
                var valueBytes = JsonConvert.SerializeObject(value, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                await _database.StringSetAsync(cacheKey, valueBytes, expirationTime);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task RemoveAsync(string key, TimeSpan? removeAt = null)
        {
            return removeAt.HasValue ? _database.KeyExpireAsync(key, removeAt) : _database.KeyDeleteAsync(key);
        }
    }
}
