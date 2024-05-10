using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RookieShop.Persistence;

public interface IDatabaseFacade
{
    public DatabaseFacade Database { get; }
}