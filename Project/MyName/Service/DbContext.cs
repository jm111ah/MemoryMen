using Microsoft.Data.SqlClient;
using MyName.Interface;
using System.Data;

namespace MyName.Service
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _config;

        public DbContext(IConfiguration config)
        {
            _config =  config;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("MM"));
        }
    }
}
