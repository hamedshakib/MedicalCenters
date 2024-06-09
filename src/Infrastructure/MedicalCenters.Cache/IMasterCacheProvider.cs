using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Cache
{
    public interface IMasterCacheProvider
    {
        Task<T?> GetAsync<T>(string cacheKey);

        Task SetAsync<T>(string cacheKey, T value, TimeSpan expirationTime);

        Task RemoveAsync(string key, TimeSpan? removeAt = null);
    }
}
