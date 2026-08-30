using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Controllers;

public class HomeController : Controller
{
    private readonly IAboutService _aboutService;
    private readonly ITestimonialService _testimonialService;
    private readonly ISkillService _skillService;
    private readonly IContactService _contactService;

    public HomeController(IAboutService aboutService, ITestimonialService testimonialService, ISkillService skillService, IContactService contactService)
    {
        _aboutService = aboutService;
        _testimonialService = testimonialService;
        _skillService = skillService;
        _contactService = contactService;
    }

    public async Task<IActionResult> Index()
    {
        var about = await _aboutService.GetAboutAsync();
        var testimonial = await _testimonialService.GetActiveTestimonialsAsync();
        var homeViewModel = new HomeViewModel
        {
            About = about,
            Testimonials = testimonial
        };
        return View(homeViewModel);
    }

    public async Task<IActionResult> About()
    {
        var about = await _aboutService.GetAboutAsync();
        var skills = await _skillService.GetAllSkillsAsync();

        var skillsViewModel = skills.Select(s => new SkillViewModel
        {
            Name = s.Name,
            DisplayOrder = s.DisplayOrder,
            Percentage = s.Percentage
        }).ToList();

        if (about is null)
        {
            return View(new AboutSkillsViewModel
            {
                About = new AboutViewModel(),
                Skills = skillsViewModel
            });
        }

        var aboutViewModel = new AboutViewModel
        {
            Title = about.Title,
            Description = about.Description,
            ImageUrl = "/" + about.ImageUrl,
            Email = about.Email,
            GithubUrl = about.GithubUrl,
            LinkedInUrl = about.LinkedInUrl,
            PhoneNumber = about.PhoneNumber,
            City = about.City,
            Age = about.Age
        };

        var model = new AboutSkillsViewModel
        {
            About = aboutViewModel,
            Skills = skillsViewModel
        };
        
        return View(model);
    }

    public IActionResult Contact()
    {
        return View(new ContactViewModel { });
    }

    [HttpPost]
    public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(contactViewModel);
        }
        var contact = new Contact
        {
            Name = contactViewModel.Name!,
            Email = contactViewModel.Email!,
            Subject = contactViewModel.Subject,
            Message = contactViewModel.Message!
        };
        await _contactService.CreateContactAsync(contact);
        TempData["SuccessMessage"] = "Your message was sent successfully. We will get back to you as soon as possible.";
        return RedirectToAction(nameof(Contact));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
