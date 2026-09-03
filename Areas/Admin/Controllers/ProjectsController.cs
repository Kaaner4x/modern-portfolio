using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Areas.Admin.Controllers;

public class ProjectsController : BaseAdminController
{
    private readonly IProjectService _projectService;
    private readonly IImageService _imageService;

    public ProjectsController(IProjectService projectService, IImageService imageService)
    {
        _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetAllProjectAsync();
        var models = projects.Select(p => new ProjectListViewModel
        {
            Id = p.Id,
            Title = p.Title,
            Description = p.Description,
            ImageUrl = !string.IsNullOrWhiteSpace(p.ImageUrl)
                ? (p.ImageUrl.StartsWith("/") || p.ImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? p.ImageUrl : "/" + p.ImageUrl)
                : null,
            ProjectUrl = p.ProjectUrl,
            GithubUrl = p.GithubUrl,
            IsActive = p.IsActive,
            Status = p.IsActive ? "Active" : "Inactive",
            CreatedDate = p.CreatedAt.ToString("MMM dd, yyyy")
        }).ToList();

        return View(models);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new ProjectCreateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var project = new Project
        {
            Title = model.Title,
            Description = model.Description,
            ProjectUrl = model.ProjectUrl ?? string.Empty,
            GithubUrl = model.GithubUrl ?? string.Empty,
            IsActive = model.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        if (model.ImageFile is not null && model.ImageFile.Length > 0)
        {
            try
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile, "projects");
                project.ImageUrl = imageUrl;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View(model);
            }
        }

        try
        {
            var projectId = await _projectService.CreateProjectAsync(project);
            if (projectId > 0)
            {
                TempData["SuccessMessage"] = "Project has been published successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to publish project.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project is null)
        {
            TempData["ErrorMessage"] = "Project not found.";
            return RedirectToAction(nameof(Index));
        }

        var model = new ProjectEditViewModel
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description,
            ProjectUrl = project.ProjectUrl,
            GithubUrl = project.GithubUrl,
            CurrentImageUrl = !string.IsNullOrWhiteSpace(project.ImageUrl)
                ? (project.ImageUrl.StartsWith("/") || project.ImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? project.ImageUrl : "/" + project.ImageUrl)
                : null,
            IsActive = project.IsActive
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProjectEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var project = await _projectService.GetProjectByIdAsync(model.Id);
        if (project is null)
        {
            TempData["ErrorMessage"] = "Project not found.";
            return RedirectToAction(nameof(Index));
        }

        project.Title = model.Title;
        project.Description = model.Description;
        project.ProjectUrl = model.ProjectUrl ?? string.Empty;
        project.GithubUrl = model.GithubUrl ?? string.Empty;
        project.IsActive = model.IsActive;

        if (model.ImageFile is not null && model.ImageFile.Length > 0)
        {
            try
            {
                if (!string.IsNullOrEmpty(project.ImageUrl))
                {
                    await _imageService.DeleteImageAsync(project.ImageUrl);
                }
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile, "projects");
                project.ImageUrl = imageUrl;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View(model);
            }
        }

        try
        {
            var result = await _projectService.UpdateProjectAsync(project);
            if (result)
            {
                TempData["SuccessMessage"] = "Project has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to update project.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project != null && !string.IsNullOrEmpty(project.ImageUrl))
            {
                await _imageService.DeleteImageAsync(project.ImageUrl);
            }

            var result = await _projectService.DeleteProjectAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Project has been deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete project.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }
}
