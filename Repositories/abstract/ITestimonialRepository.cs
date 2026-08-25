using System;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.concrete;

namespace ModernPortfolio.Repositories.@abstract;

public interface ITestimonialRepository : IGenericRepository<Testimonial>
{
    Task<IEnumerable<Testimonial>> GetActiveTestimonialsAsync();
}
