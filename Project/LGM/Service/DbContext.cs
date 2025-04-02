using LGM.Interface;
using System.Data;
using System.Data.SqlClient;

namespace LGM.Service
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _config;

        public DbContext(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("MM"));
        }
    }
}
