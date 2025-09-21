using System.Data;

namespace TrafficProcessor.Interface;

public interface IUtil
{
    public IDbConnection Connection();
}