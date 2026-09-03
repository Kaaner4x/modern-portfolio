using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ModernPortfolio.ViewModels;

public class TestimonialCreateViewModel
{
    [Required(ErrorMessage = "Client name is required.")]
    [StringLength(100, ErrorMessage = "Client name cannot exceed 100 characters.")]
    [Display(Name = "Client / Reviewer Name")]
    public string ClientName { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Client position cannot exceed 100 characters.")]
    [Display(Name = "Company / Title / Position")]
    public string? ClientPosition { get; set; }

    [Required(ErrorMessage = "Testimonial comment is required.")]
    [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters.")]
    [Display(Name = "Feedback / Comment")]
    public string Comment { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rating is required.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars.")]
    [Display(Name = "Star Rating (1 - 5)")]
    public int Rating { get; set; } = 5;

    [Display(Name = "Client Avatar / Photo")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "Active / Display on Site")]
    public bool IsActive { get; set; } = true;
}
