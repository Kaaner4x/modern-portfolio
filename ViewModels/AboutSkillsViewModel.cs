using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.ViewModels;

public class AboutSkillsViewModel
{
    public AboutViewModel? About { get; set; }
    public List<SkillViewModel> Skills { get; set; } = [];
    public int GetSkillsCount() => Skills.Count;
}
