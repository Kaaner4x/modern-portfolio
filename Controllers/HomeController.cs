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

    public HomeController(IAboutService aboutService, ITestimonialService testimonialService)
    {
        _aboutService = aboutService;
        _testimonialService = testimonialService;
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
        if(about is null)
        {
            return View(new AboutViewModel());
        }
        var model = new AboutViewModel
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
        return View(model);
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
