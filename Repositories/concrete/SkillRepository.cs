using System;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;

namespace ModernPortfolio.Repositories.concrete;

public class SkillRepository : GenericRepository<Skill>, ISkillRepository
{
    public SkillRepository(IConfiguration configuration) : base(configuration)
    {
    }
}
