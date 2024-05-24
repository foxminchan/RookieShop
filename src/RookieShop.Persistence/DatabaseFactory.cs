using System.Data;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace RookieShop.Persistence;

public sealed class DatabaseFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public DatabaseFactory(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("shopdb");
        Guard.Against.Null(connectionString, message: "Connection string 'Postgres' not found.");
        _connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection() => new NpgsqlConnection(_connectionString);
}