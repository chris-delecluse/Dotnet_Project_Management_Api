using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ProjectManagement.Database.Adapter;

public class AppDbContext : IAppDbContext
{
    private readonly string _connectionString;

    public AppDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default")!;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; 
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}

public interface IAppDbContext
{
    public IDbConnection CreateConnection();
}
