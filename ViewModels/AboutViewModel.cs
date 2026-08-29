using System;

namespace ModernPortfolio.ViewModels;

public class AboutViewModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? PhoneNumber { get; set; }
    public string? City { get; set; }
    public int Age { get; set; }
}
