using System.Data;
using Microsoft.Data.SqlClient;
using TrafficProcessor.Interface;

namespace TrafficProcessor.Util;

public class DbService : IUtil
{
    private readonly IConfiguration _configuration;

    public DbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Connection()
    {
        return new SqlConnection(_configuration.GetConnectionString("MemoryManDB"));
    }
}