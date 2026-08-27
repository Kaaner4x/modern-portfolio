using System;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using ModernPortfolio.Services.@abstract;

namespace ModernPortfolio.Services.concrete;

public class TestimonialService : ITestimonialService
{
    private readonly ITestimonialRepository _repository;

    public TestimonialService(ITestimonialRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<int> CreateTestimonialAsync(Testimonial testimonial)
    {
        if (testimonial is null)
        {
            throw new ArgumentNullException("Testimonial cannot be null!", nameof(testimonial));
        }
        ValidateTestimonial(testimonial);
        testimonial.CreatedAt = DateTime.UtcNow;

        var result = await _repository.CreateAsync(testimonial);
        return result;
    }

    public async Task<bool> DeleteTestimonialAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Testimonial ID must be greater then zero!", nameof(id));
        }
        var testimonial = await _repository.GetByIdAsync(id);
        if (testimonial is null)
        {
            return false;
        }
        var result = await _repository.DeleteAsync(id);
        return result;
    }

    public async Task<IEnumerable<Testimonial>> GetActiveTestimonialsAsync()
    {
        var testimonials = await _repository.GetActiveTestimonialsAsync();
        var result = testimonials.OrderByDescending(t => t.Rating).ThenByDescending(t => t.CreatedAt);
        return result;
    }

    public async Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync()
    {
        var testimonials = await _repository.GetAllAsync();
        var result = testimonials.OrderByDescending(t => t.Rating).ThenByDescending(t => t.CreatedAt);
        return result;
    }

    public async Task<Testimonial?> GetTestimonialByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Testimonial ID must be greater then zero!", nameof(id));
        }
        var result = await _repository.GetByIdAsync(id);
        return result;
    }

    public async Task<bool> UpdateTestimonialAsync(Testimonial testimonial)
    {
        if (testimonial is null)
        {
            throw new ArgumentNullException("Testimonial cannot be null!", nameof(testimonial));
        }
        if (testimonial.Id <= 0)
        {
            throw new ArgumentException("Testimonial ID must be greater than zero!", nameof(testimonial));
        }
        var existingTestimonial = await _repository.GetByIdAsync(testimonial.Id);
        if (existingTestimonial is null)
        {
            throw new ArgumentNullException($"Testimonial with ID {testimonial.Id} not found!", nameof(testimonial));
        }
        ValidateTestimonial(testimonial);

        testimonial.CreatedAt = existingTestimonial.CreatedAt;

        var result = await _repository.UpdateAsync(testimonial);
        return result;
    }

    private void ValidateTestimonial(Testimonial testimonial)
    {
        // ClientName
        if (string.IsNullOrWhiteSpace(testimonial.ClientName))
        {
            throw new ArgumentException("Testimonial client name cannot be emtpy or whitespace!", nameof(testimonial));
        }
        if (testimonial.ClientName.Length > 100)
        {
            throw new ArgumentException("Testimonial client name cannot exceed 100 chracters!", nameof(testimonial));
        }

        // ClientPosition
        if (string.IsNullOrWhiteSpace(testimonial.ClientPosition) && testimonial.ClientPosition.Length > 100)
        {
            throw new ArgumentException("Testimonial client position cannot exceed 100 chracters!", nameof(testimonial));
        }

        // Comment
        if (string.IsNullOrWhiteSpace(testimonial.Comment))
        {
            throw new ArgumentException("Testimonial comment name cannot be emtpy or whitespace!", nameof(testimonial));
        }

        // ClientImageUrl
        if (!string.IsNullOrWhiteSpace(testimonial.ClientImageUrl) && testimonial.ClientImageUrl.Length > 500)
        {
            throw new ArgumentException("Testimonial client image url cannot exceed 500 chracters!", nameof(testimonial));
        }

        if (testimonial.Rating < 1 || testimonial.Rating > 5)
        {
            throw new ArgumentException("Rating must be between 1 and 5", nameof(testimonial));
        }
    }
}
