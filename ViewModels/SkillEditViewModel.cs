using System.ComponentModel.DataAnnotations;

namespace ModernPortfolio.ViewModels;

public class SkillEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Skill name is required.")]
    [StringLength(50, ErrorMessage = "Skill name cannot exceed 50 characters.")]
    [Display(Name = "Skill Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Proficiency percentage is required.")]
    [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
    [Display(Name = "Proficiency Percentage (%)")]
    public int Percentage { get; set; }

    [Range(0, 9999, ErrorMessage = "Display order must be a non-negative number.")]
    [Display(Name = "Display Order")]
    public int DisplayOrder { get; set; }
}
