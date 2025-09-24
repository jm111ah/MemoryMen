using Microsoft.Extensions.Caching.Memory;
using TrafficProcessor.Dto;
using TrafficProcessor.Interface;

namespace TrafficProcessor.Service;

public class CacheService : ICache
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Task<T> GetAsync<T>(CacheDto cacheDto) where T : class
    {
        _memoryCache.TryGetValue(cacheDto.Key, out T? value);
        return Task.FromResult(value);
    }

    public Task SetAsync<T>(CacheDto cacheDto, T value) where T : class
    {
        var option = new MemoryCacheEntryOptions();

        if (cacheDto.TimeSpan.HasValue)
        {
            option.SetAbsoluteExpiration(cacheDto.TimeSpan.Value);
        }
        
        _memoryCache.Set(cacheDto.Key, value, option);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(CacheDto cacheDto)
    {
        _memoryCache.Remove(cacheDto.Key);
        return Task.CompletedTask;
    }
}