using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Services.@abstract;

public interface ISkillService
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task<Skill?> GetSkillByIdAsync();
    Task<int> CreateSkillAsync(Skill skill);
    Task<bool> UpdateSkillAsync(Skill skill);
    Task<bool> DeleteSkillAsync(int id);
}
