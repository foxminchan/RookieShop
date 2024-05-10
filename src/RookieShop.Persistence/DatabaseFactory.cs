using System.Data;
using Ardalis.GuardClauses;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace RookieShop.Persistence;

public sealed class DatabaseFactory : IDatabaseFactory
{
    private readonly string _connectionString;

    public DatabaseFactory(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
        _connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}