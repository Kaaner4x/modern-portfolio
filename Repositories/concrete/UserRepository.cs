using System;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using Npgsql;

namespace ModernPortfolio.Repositories.concrete;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(IConfiguration configuration, string? tableName = null) : base(configuration, tableName)
    {
    }

    public async Task<User?> GetUserByUserNameAsync(string userName)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = "SELECT * FROM Users WHERE UserName = @UserName";
        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { UserName = userName });
    }
}
