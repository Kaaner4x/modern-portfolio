using System;
using Dapper;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using Npgsql;

namespace ModernPortfolio.Repositories.concrete;

public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    public ContactRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<IEnumerable<Contact>> GetUnreadMessagesAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = $"SELECT * FROM Contacts WHERE IsRead = @IsRead ORDER BY CreatedAt DESC";
        var result = await connection.QueryAsync<Contact>(sql, new {IsRead = false});
        return result;
    }
}
