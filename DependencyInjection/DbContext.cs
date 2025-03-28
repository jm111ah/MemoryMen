using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DependencyInjection
{
    public class DbContext : IDbContext
    {

        public string GetName()
        {
            return "Memory Man";
        }
    }
}
