namespace ModernPortfolio.ViewModels;

public class ProjectListViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? ProjectUrl { get; set; }
    public string? GithubUrl { get; set; }
    public bool IsActive { get; set; }
    public string Status { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
}
