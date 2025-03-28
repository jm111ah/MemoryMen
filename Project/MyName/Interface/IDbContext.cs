using System.Data;

namespace MyName.Interface
{
    public interface IDbContext
    {
       public IDbConnection GetConnection();
    }
}
