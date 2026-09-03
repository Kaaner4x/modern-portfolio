using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Controllers;

public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetActiveProjectAsync();
        var model = projects.Select(p => new ProjectViewModel
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            ImageUrl = string.IsNullOrEmpty(p.ImageUrl) 
                ? "/ui/img/portfolio/portfolio-1.jpg" 
                : (p.ImageUrl.StartsWith("/") ? p.ImageUrl : "/" + p.ImageUrl),
            ProjectUrl = p.ProjectUrl,
            GithubUrl = p.GithubUrl,
            CreatedAt = p.CreatedAt,
            IsActive = p.IsActive
        }).ToList();

        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null || !project.IsActive)
        {
            return NotFound();
        }

        var model = new ProjectViewModel
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description,
            ImageUrl = string.IsNullOrEmpty(project.ImageUrl) 
                ? "/ui/img/portfolio/portfolio-1.jpg" 
                : (project.ImageUrl.StartsWith("/") ? project.ImageUrl : "/" + project.ImageUrl),
            ProjectUrl = project.ProjectUrl,
            GithubUrl = project.GithubUrl,
            CreatedAt = project.CreatedAt,
            IsActive = project.IsActive
        };

        return View(model);
    }
}
