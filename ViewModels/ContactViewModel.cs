using System.ComponentModel.DataAnnotations;

namespace ModernPortfolio.ViewModels;

public class ContactViewModel
{
    [Display(Name = "Your Name")]
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Your Email")]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Subject")]
    [Required(ErrorMessage = "Subject is required.")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Subject must be between 3 and 200 characters.")]
    public string Subject { get; set; } = string.Empty;

    [Display(Name = "Message")]
    [Required(ErrorMessage = "Message is required.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters.")]
    public string Message { get; set; } = string.Empty;
}


