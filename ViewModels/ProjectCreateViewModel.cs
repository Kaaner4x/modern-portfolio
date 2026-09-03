using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ModernPortfolio.ViewModels;

public class ProjectCreateViewModel
{
    [Required(ErrorMessage = "Project title is required.")]
    [StringLength(200, ErrorMessage = "Project title cannot exceed 200 characters.")]
    [Display(Name = "Project Title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Project description is required.")]
    [Display(Name = "Project Description")]
    public string Description { get; set; } = string.Empty;

    [Url(ErrorMessage = "Please enter a valid Live Project URL (e.g., https://myproject.com).")]
    [StringLength(500, ErrorMessage = "Project URL cannot exceed 500 characters.")]
    [Display(Name = "Live Demo / Website URL")]
    public string? ProjectUrl { get; set; }

    [Url(ErrorMessage = "Please enter a valid GitHub repository URL (e.g., https://github.com/user/repo).")]
    [StringLength(500, ErrorMessage = "GitHub URL cannot exceed 500 characters.")]
    [Display(Name = "GitHub Repository URL")]
    public string? GithubUrl { get; set; }

    [Display(Name = "Project Cover Image")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "Active / Published Status")]
    public bool IsActive { get; set; } = true;
}
