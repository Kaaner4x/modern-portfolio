using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Services.@abstract;

public interface ITestimonialService
{
    Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync();
    Task<IEnumerable<Testimonial>> GetActiveTestimonialsAsync();
    Task<Testimonial?> GetTestimonialByIdAsync(int id);
    Task<int> CreateTestimonialAsync(Testimonial testimonial);
    Task<bool> UpdateTestimonialAsync(Testimonial testimonial);
    Task<bool> DeleteTestimonialAsync(int id);
}
