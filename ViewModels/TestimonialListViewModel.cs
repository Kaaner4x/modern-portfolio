namespace ModernPortfolio.ViewModels;

public class TestimonialListViewModel
{
    public int Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string? ClientPosition { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string? ClientImageUrl { get; set; }
    public int Rating { get; set; }
    public bool IsActive { get; set; }
    public string Status { get; set; } = string.Empty;
    public string CreatedDate { get; set; } = string.Empty;
}
