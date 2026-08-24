using System;
using Dapper;
using ModernPortfolio.Repositories.@abstract;
using Npgsql;

namespace ModernPortfolio.Repositories.concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly string _connectionString;
    private readonly string _tableName;

    public GenericRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found!");

        _tableName = typeof(T).Name + "s";
    }
    public async Task<int> CreateAsync(T entity)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.GetValue(entity) != null)
            .ToList();

        var propertyNames = properties.Select(p => p.Name).ToArray();
        var paramaterNames = propertyNames.Select(p => $"@{p}").ToArray();

        var sql = $"INSERT INTO {_tableName} ({string.Join(", ", propertyNames)})" +
                  $"VALUES ({string.Join(", ", paramaterNames)})" +
                  $"RETURNING ID";

        var id = await connection.QuerySingleAsync<int>(sql, entity);
        return id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = $"SELECT * from {_tableName}";
        var result = await connection.QueryAsync<T>(sql);
        return result;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = $"SELECT * FROM {_tableName} WHERE Id=@Id";
        var result = await connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
        return result;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.GetValue(entity) != null && p.Name != "CreatedAt")
            .ToList();

        var setClause = string.Join(", ", properties.Select(p => $"{p.Name}=${p.Name}"));
        var sql = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";
        var affectedRows = await connection.ExecuteAsync(sql, entity);
        return affectedRows > 0;
    }
}
