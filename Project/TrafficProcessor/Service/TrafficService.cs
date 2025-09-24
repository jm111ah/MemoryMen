using TrafficProcessor.Dto;
using TrafficProcessor.Interface;
using TrafficProcessor.Repository;

namespace TrafficProcessor.Service;

public class TrafficService : ITrafficService
{
    private readonly ITrafficRepository _trafficRepository;

    public TrafficService(ITrafficRepository trafficRepository)
    {
        _trafficRepository = trafficRepository;
    }

    public List<ResponseTrafficDto> GetTraffic()
    {
        return _trafficRepository.GetTraffic().Select(entity => new ResponseTrafficDto
        {
            IsResult = true
        }).ToList();

        // return new();
    }

    public async Task<List<ResponseTrafficDto>> GetTrafficAsync()
    {
        var data = await _trafficRepository.GetTrafficAsync();
        return data.Select(entity => new ResponseTrafficDto
        {
            IsResult = true
        }).ToList();
    }
    
    public async Task<List<ResponseTrafficDto>> GetTrafficCacheAsync()
    {
        var data = await _trafficRepository.GetTrafficCacheAsync();
        return data.Select(entity => new ResponseTrafficDto
        {
            IsResult = true
        }).ToList();
    }
}