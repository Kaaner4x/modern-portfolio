using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ModernPortfolio.ViewModels;

public class AboutCreateViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    [Display(Name = "Title / Headline")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [Display(Name = "Biography / Description")]
    public string Description { get; set; } = string.Empty;

    [Range(0, 120, ErrorMessage = "Please enter a valid age between 0 and 120.")]
    [Display(Name = "Age")]
    public int Age { get; set; }

    [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
    [Display(Name = "City / Location")]
    public string? City { get; set; }

    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
    [Display(Name = "Email Address")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    [StringLength(30, ErrorMessage = "Phone number cannot exceed 30 characters.")]
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Url(ErrorMessage = "Please enter a valid GitHub URL.")]
    [StringLength(250, ErrorMessage = "GitHub URL cannot exceed 250 characters.")]
    [Display(Name = "GitHub Profile URL")]
    public string? GithubUrl { get; set; }

    [Url(ErrorMessage = "Please enter a valid LinkedIn URL.")]
    [StringLength(250, ErrorMessage = "LinkedIn URL cannot exceed 250 characters.")]
    [Display(Name = "LinkedIn Profile URL")]
    public string? LinkedInUrl { get; set; }

    [Display(Name = "Profile Photo")]
    public IFormFile? ImageFile { get; set; }
}
