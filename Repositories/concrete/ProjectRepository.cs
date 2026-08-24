using System;
using Dapper;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using Npgsql;

namespace ModernPortfolio.Repositories.concrete;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<IEnumerable<Project>> GetActiveProjectsAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = $"SELECT * FROM Projects WHERE IsActive = @IsActive";
        var result = await connection.QueryAsync<Project>(sql, new { IsActive = true });
        return result;
    }
}
