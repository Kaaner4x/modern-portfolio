using System;

namespace ModernPortfolio.ViewModels;

public class SkillViewModel
{
    public string Name { get; set; } = string.Empty;
    public int Percentage { get; set; }
    public int DisplayOrder { get; set; }
}
