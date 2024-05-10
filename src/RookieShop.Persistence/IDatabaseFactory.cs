using System.Data;

namespace RookieShop.Persistence;

public interface IDatabaseFactory
{
    IDbConnection GetOpenConnection();
}