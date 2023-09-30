using Dapper;

namespace ProjectManagement.Database.Adapter.Extensions;

internal static class DapperExtension
{
    internal static async Task<TEntity> InsertAsync<TEntity>(
        this IAppDbContext dbContext,
        string sql,
        object parameters
    )
    {
        using var db = dbContext.CreateConnection();

        return (await db.QueryAsync<TEntity>(sql, parameters)).Single();
    }

    internal static async Task<IEnumerable<TEntity>> FindAsync<TEntity>(this IAppDbContext dbContext, string sql)
    {
        using var db = dbContext.CreateConnection();

        return await db.QueryAsync<TEntity>(sql);
    }

    internal static async Task<IEnumerable<TEntity>> FindAsync<TEntity>(
        this IAppDbContext dbContext,
        string sql,
        object parameters
    )
    {
        using var db = dbContext.CreateConnection();
        
        return await db.QueryAsync<TEntity>(sql, parameters);
    }
}
