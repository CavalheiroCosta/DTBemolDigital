using Microsoft.Extensions.Caching.Memory;

namespace Customer.Domain.Util
{
    public class CacheUtil : ICacheUtil
    {
        private readonly IMemoryCache _memoryCache;
        private readonly DateTimeOffset _cacheExpiration;

        public CacheUtil(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _cacheExpiration = DateTimeOffset.UtcNow.AddHours(8);
        }

        public T GetValue<T>(string key) where T : class
        {
            _memoryCache.TryGetValue(key, out T value);
            return value;
        }

        public void SetValue<T>(string key, T value)
        {
            _memoryCache.Set(key, value, _cacheExpiration);
        }
    }
}
