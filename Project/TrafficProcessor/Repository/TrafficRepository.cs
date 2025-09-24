using System.Data;
using Dapper;
using TrafficProcessor.Dto;
using TrafficProcessor.Entity;
using TrafficProcessor.Interface;

namespace TrafficProcessor.Repository;

public class TrafficRepository : ITrafficRepository
{
    private readonly IUtil _util;
    private readonly IConfiguration _config;
    private readonly ICache _memoryCache;

    public TrafficRepository(IUtil util, IConfiguration config, ICache memoryCache)
    {
        _util = util;
        _config = config;
        _memoryCache = memoryCache;
    }

    public List<TrafficEntity> GetTraffic()
    {
        using (var con = _util.Connection())
        {
            var param = new DynamicParameters();
            var result = con.Query<TrafficEntity>("Get_TrafficTable", param ,commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
    }

    public async Task<List<TrafficEntity>> GetTrafficAsync()
    {
        using (var con = _util.Connection())
        {
            var param = new DynamicParameters();
            var result = await con.QueryAsync<TrafficEntity>("Get_TrafficTable", param, commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
    }

    public async Task<List<TrafficEntity>> GetTrafficCacheAsync()
    {
        var cacheDto = new CacheDto
        {
            Key = "GetCacheAsync",
            TimeSpan = TimeSpan.FromMinutes(30)
        };

        var cacheData = await _memoryCache.GetAsync<List<TrafficEntity>>(cacheDto);
        
        if (cacheData != null)
        {
            return cacheData;
        }
        
        using (var con = _util.Connection())
        {
            var param = new DynamicParameters();
            var data = await con.QueryAsync<TrafficEntity>("Get_TrafficTable", param, commandType:CommandType.StoredProcedure);
            var result = data.ToList();
            
            await _memoryCache.SetAsync(cacheDto,result);
            
            return result.ToList();
        }
    }
}