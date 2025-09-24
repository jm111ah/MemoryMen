using TrafficProcessor.Dto;

namespace TrafficProcessor.Interface;

public interface ICache
{
    Task<T> GetAsync<T>(CacheDto cacheDto) where T : class;
    Task SetAsync<T>(CacheDto cacheDto, T value) where T : class;
    Task RemoveAsync(CacheDto cacheDto);
}