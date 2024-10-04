using Microsoft.Extensions.Caching.Memory;

namespace Chat.Api.Manager;

public class MemoryCacheManager(IMemoryCache memoryCache)
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    public  void GetOrUpdateDtos(string key, object dtos)
    {
        _memoryCache.Set(key, dtos);
    }

    public object? GetDtos(string key)
    {
        if (_memoryCache.TryGetValue(key, out object value))
        {
            return value;
        }

        return null;
    }
}