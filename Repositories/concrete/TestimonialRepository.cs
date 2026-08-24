using System;
using Dapper;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using Npgsql;

namespace ModernPortfolio.Repositories.concrete;

public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
{
    public TestimonialRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<IEnumerable<Testimonial>> GetActiveTestimonialsAsync()
    {   
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = $"SELECT * FROM Testimonials WHERE IsActive = @IsActive";
        var result = await connection.QueryAsync<Testimonial>(sql, new { IsActive = true });
        return result;
    }
}
