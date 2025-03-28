using System.Data;

namespace MyName.Interface
{
    public interface IDbContext
    {
        IDbConnection GetConnection();
    }
}
