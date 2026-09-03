using System;

namespace ModernPortfolio.ViewModels;

public class ProjectViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; } 
    public string? Description { get; set; }
    public string? ImageUrl { get; set; } 
    public string? ProjectUrl { get; set; } 
    public string? GithubUrl { get; set; } 
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}