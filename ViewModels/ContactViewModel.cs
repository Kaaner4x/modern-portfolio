using System.ComponentModel.DataAnnotations;

namespace ModernPortfolio.ViewModels;

public class ContactViewModel
{
    [Display(Name = "Your Name")]
    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Your Email")]
    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 255 characters.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Subject")]
    [Required(ErrorMessage = "Please enter a subject.")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Subject must be between 3 and 200 characters.")]
    public string? Subject { get; set; }

    [Display(Name = "Message")]
    [Required(ErrorMessage = "Please enter your message.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters.")]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; } = string.Empty;
}


