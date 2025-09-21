using TrafficProcessor.Dto;

namespace TrafficProcessor.Interface;

public interface ITrafficService
{
    public List<ResponseTrafficDto> GetTraffic();
    public Task<List<ResponseTrafficDto>> GetTrafficAsync();
}