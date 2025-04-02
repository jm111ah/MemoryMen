using System.Data;

namespace LGM.Interface
{
    public interface IDbContext
    {
        public IDbConnection GetConnection();
    }
}
