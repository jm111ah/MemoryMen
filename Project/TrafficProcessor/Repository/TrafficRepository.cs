using System.Data;
using Dapper;
using TrafficProcessor.Entity;
using TrafficProcessor.Interface;

namespace TrafficProcessor.Repository;

public class TrafficRepository : ITrafficRepository
{
    private readonly IUtil _util;
    private readonly IConfiguration _config;

    public TrafficRepository(IUtil util, IConfiguration config)
    {
        _util = util;
        _config = config;
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
}