namespace MedicalCenters.Cache;

public interface IMasterCacheProvider
{
    T? GetMemoryCache<T>(string cacheKey);
    Task<T?> GetDistributedCacheAsync<T>(string cacheKey);

    void SetMemoryCache<T>(string cacheKey, T value, TimeSpan? expirationTime = null);
    Task SetDistributedCacheAsync<T>(string cacheKey, T value, TimeSpan? expirationTime = null);

    Task RemoveMemoryCacheAsync(string key);
    Task RemoveDistributedCacheAsync(string key, TimeSpan? removeAt = null);
}