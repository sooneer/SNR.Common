using Microsoft.Extensions.Caching.Memory;

namespace SNR.Common;

public class CacheProvider : ICacheProvider
{
    private readonly MemoryCache _memoryCache;

    public CacheProvider()
    {
        _memoryCache = new MemoryCache(
            new MemoryCacheOptions
            {
                SizeLimit = 1024
            });
    }

    public TType Get<TType>(string key) where TType : class
    {
        return _memoryCache.Get<TType>(key);
    }

    public void Set(string key, object value, TimeSpan expire)
    {
        _memoryCache.Set(key, value, expire);
    }

    public void Clear()
    {
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public bool Exists(string key)
    {
        var result = _memoryCache.Get(key);
        return result != null;
    }
}