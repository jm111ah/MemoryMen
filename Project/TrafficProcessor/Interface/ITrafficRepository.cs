using TrafficProcessor.Entity;

namespace TrafficProcessor.Interface;

public interface ITrafficRepository
{
    public List<TrafficEntity> GetTraffic();
    public Task<List<TrafficEntity>>  GetTrafficAsync();
}