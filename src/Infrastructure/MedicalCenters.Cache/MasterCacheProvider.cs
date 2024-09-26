using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Cache
{
    internal class MasterCacheProvider : IMasterCacheProvider
    {
        private const string UpdateChannelName = "updateChannel";

        private MemoryCache? _memoryCache ;
        private readonly IDatabase _redisDatabase;

        private readonly ISubscriber _subscriber ;
        public MasterCacheProvider(ConnectionMultiplexer redisConnection)
        {
            _redisDatabase = redisConnection.GetDatabase();
            _subscriber = redisConnection.GetSubscriber();
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            redisConnection.ConnectionFailed += (sender, args) =>
            {
                _memoryCache.Dispose();
                _memoryCache = null;
            };

            redisConnection.ConnectionRestored += (sender, args) =>
            {
                _memoryCache = new MemoryCache(new MemoryCacheOptions());
            };

            _subscriber.Subscribe(UpdateChannelName, (channel, message) =>
            {
                RemoveMemoryCache(message);
            });
        }
        public async Task<T?> GetDistributedCacheAsync<T>(string cacheKey)
        {
            try
            {
                var value = await _redisDatabase.StringGetAsync(cacheKey);

                if (value.IsNull || !value.HasValue)
                    return default(T);

                return JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task SetDistributedCacheAsync<T>(string cacheKey, T value, TimeSpan? expirationTime)
        {
            try
            {
                var valueBytes = JsonConvert.SerializeObject(value, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                await _redisDatabase.StringSetAsync(cacheKey, valueBytes, expirationTime);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task RemoveDistributedCacheAsync(string key, TimeSpan? removeAt = null)
        {
            return removeAt.HasValue ? _redisDatabase.KeyExpireAsync(key, removeAt) : _redisDatabase.KeyDeleteAsync(key);
        }

        public T? GetMemoryCache<T>(string cacheKey)
        {
            var value = _memoryCache?.Get(cacheKey);

            if (value is null)
                return default(T);

            return (T)value;
        }

        public void SetMemoryCache<T>(string cacheKey, T value, TimeSpan? expirationTime)
        {

            if (expirationTime == null)
            {
                _memoryCache?.Set(cacheKey, value);
            }
            else
            {
                _memoryCache?.Set(cacheKey, value, (TimeSpan)expirationTime);
            }
        }

        public async Task RemoveMemoryCacheAsync(string key)
        {
            RemoveMemoryCache(key);
            await _subscriber.PublishAsync(UpdateChannelName, key);
        }

        private void RemoveMemoryCache(string key)
        {
            _memoryCache?.Remove(key);
        }
    }
}
