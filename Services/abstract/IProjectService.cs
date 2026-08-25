using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Services.@abstract;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectAsync();
    Task<IEnumerable<Project>> GetActiveProjectAsync();
    Task<Project?> GetProjectByIdAsync(int id);
    Task<int> CreateProjectAsync(Project project);
    Task<bool> UpdateProjectAsync(Project project);
    Task<bool> DeleteProjectAsync(int id);
}
