using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<ActionResult> Index()
        {
            var projects = await _projectService.GetActiveProjectAsync();
            var model = projects.Select(p=> new ProjectViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ImageUrl = "/" + p.ImageUrl,
                GithubUrl = p.GithubUrl,
                CreatedAt = p.CreatedAt,
                IsActive = p.IsActive
            }).ToList();
            return View(model);
        }

    }
}
