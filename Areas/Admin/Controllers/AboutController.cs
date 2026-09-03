using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Areas.Admin.Controllers
{
    public class AboutController : BaseAdminController
    {
        private readonly IAboutService _aboutService;
        private readonly IImageService _imageService;

        public AboutController(IAboutService aboutService, IImageService imageService)
        {
            _aboutService = aboutService ?? throw new ArgumentNullException(nameof(aboutService));
            _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAboutAsync();
            if (about is null)
            {
                return View((AboutEditViewModel?)null);
            }

            var model = new AboutEditViewModel
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                Age = about.Age,
                City = about.City,
                Email = about.Email,
                GithubUrl = about.GithubUrl,
                LinkedInUrl = about.LinkedInUrl,
                PhoneNumber = about.PhoneNumber,
                CurrentImageUrl = !string.IsNullOrEmpty(about.ImageUrl) 
                    ? (about.ImageUrl.StartsWith("/") || about.ImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? about.ImageUrl : "/" + about.ImageUrl) 
                    : null
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AboutCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", (AboutEditViewModel?)null);
            }

            var about = new About
            {
                Title = model.Title,
                Description = model.Description,
                Age = model.Age,
                City = model.City,
                Email = model.Email,
                GithubUrl = model.GithubUrl,
                LinkedInUrl = model.LinkedInUrl,
                PhoneNumber = model.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            if (model.ImageFile is not null && model.ImageFile.Length > 0)
            {
                try
                {
                    var imageUrl = await _imageService.SaveImageAsync(model.ImageFile, "about");
                    about.ImageUrl = imageUrl;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View("Index", (AboutEditViewModel?)null);
                }
            }

            try
            {
                var aboutId = await _aboutService.CreateAboutAsync(about);
                if (aboutId > 0)
                {
                    TempData["SuccessMessage"] = "About information has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Failed to create about information.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
            }

            return View("Index", (AboutEditViewModel?)null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AboutEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var about = await _aboutService.GetAboutAsync();
            if (about is null || about.Id != model.Id)
            {
                TempData["ErrorMessage"] = "About record not found.";
                return RedirectToAction(nameof(Index));
            }

            about.Title = model.Title;
            about.Description = model.Description;
            about.Age = model.Age;
            about.City = model.City;
            about.Email = model.Email;
            about.GithubUrl = model.GithubUrl;
            about.LinkedInUrl = model.LinkedInUrl;
            about.PhoneNumber = model.PhoneNumber;
            about.UpdatedAt = DateTime.UtcNow;

            if (model.ImageFile is not null && model.ImageFile.Length > 0)
            {
                try
                {
                    if (!string.IsNullOrEmpty(about.ImageUrl))
                    {
                        await _imageService.DeleteImageAsync(about.ImageUrl);
                    }
                    var imageUrl = await _imageService.SaveImageAsync(model.ImageFile, "about");
                    about.ImageUrl = imageUrl;
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View("Index", model);
                }
            }

            try
            {
                var result = await _aboutService.UpdateAboutAsync(about);
                if (result)
                {
                    TempData["SuccessMessage"] = "About information has been updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Failed to update about information.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
            }

            return View("Index", model);
        }
    }
}
