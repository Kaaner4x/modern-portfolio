using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Repositories.@abstract;

public interface IProjectRepository : IGenericRepository<Project>
{
    Task<IEnumerable<Project>> GetActiveProjectsAsync();
}
