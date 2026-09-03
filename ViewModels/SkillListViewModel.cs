namespace ModernPortfolio.ViewModels;

public class SkillListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Percentage { get; set; }
    public int DisplayOrder { get; set; }
    public string CreatedDate { get; set; } = string.Empty;
}
