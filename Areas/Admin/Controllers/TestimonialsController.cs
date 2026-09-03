using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Areas.Admin.Controllers;

public class TestimonialsController : BaseAdminController
{
    private readonly ITestimonialService _testimonialService;
    private readonly IImageService _imageService;

    public TestimonialsController(ITestimonialService testimonialService, IImageService imageService)
    {
        _testimonialService = testimonialService ?? throw new ArgumentNullException(nameof(testimonialService));
        _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var testimonials = await _testimonialService.GetAllTestimonialsAsync();
        var models = testimonials.Select(t => new TestimonialListViewModel
        {
            Id = t.Id,
            ClientName = t.ClientName,
            ClientPosition = t.ClientPosition,
            Rating = t.Rating,
            Comment = t.Comment,
            ClientImageUrl = !string.IsNullOrWhiteSpace(t.ClientImageUrl)
                ? (t.ClientImageUrl.StartsWith("/") || t.ClientImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? t.ClientImageUrl : "/" + t.ClientImageUrl)
                : null,
            IsActive = t.IsActive,
            Status = t.IsActive ? "Approved & Live" : "Pending Approval",
            CreatedDate = t.CreatedAt.ToString("MMM dd, yyyy")
        }).ToList();

        return View(models);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new TestimonialCreateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(TestimonialCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var testimonial = new Testimonial
        {
            ClientName = model.ClientName,
            ClientPosition = model.ClientPosition ?? string.Empty,
            Comment = model.Comment,
            Rating = model.Rating,
            IsActive = model.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        if (model.ImageFile is not null && model.ImageFile.Length > 0)
        {
            try
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile, "testimonials");
                testimonial.ClientImageUrl = imageUrl;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View(model);
            }
        }

        try
        {
            var testimonialId = await _testimonialService.CreateTestimonialAsync(testimonial);
            if (testimonialId > 0)
            {
                TempData["SuccessMessage"] = "Review has been submitted successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to submit review.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var testimonial = await _testimonialService.GetTestimonialByIdAsync(id);
        if (testimonial is null)
        {
            TempData["ErrorMessage"] = "Review not found.";
            return RedirectToAction(nameof(Index));
        }

        var model = new TestimonialEditViewModel
        {
            Id = testimonial.Id,
            ClientName = testimonial.ClientName,
            ClientPosition = testimonial.ClientPosition,
            Comment = testimonial.Comment,
            Rating = testimonial.Rating,
            CurrentImageUrl = !string.IsNullOrWhiteSpace(testimonial.ClientImageUrl)
                ? (testimonial.ClientImageUrl.StartsWith("/") || testimonial.ClientImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? testimonial.ClientImageUrl : "/" + testimonial.ClientImageUrl)
                : null,
            IsActive = testimonial.IsActive
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(TestimonialEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var testimonial = await _testimonialService.GetTestimonialByIdAsync(model.Id);
        if (testimonial is null)
        {
            TempData["ErrorMessage"] = "Review not found.";
            return RedirectToAction(nameof(Index));
        }

        testimonial.ClientName = model.ClientName;
        testimonial.ClientPosition = model.ClientPosition ?? string.Empty;
        testimonial.Comment = model.Comment;
        testimonial.Rating = model.Rating;
        testimonial.IsActive = model.IsActive;

        if (model.ImageFile is not null && model.ImageFile.Length > 0)
        {
            try
            {
                if (!string.IsNullOrEmpty(testimonial.ClientImageUrl))
                {
                    await _imageService.DeleteImageAsync(testimonial.ClientImageUrl);
                }
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile, "testimonials");
                testimonial.ClientImageUrl = imageUrl;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View(model);
            }
        }

        try
        {
            var result = await _testimonialService.UpdateTestimonialAsync(testimonial);
            if (result)
            {
                TempData["SuccessMessage"] = "Review has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to update review.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var testimonial = await _testimonialService.GetTestimonialByIdAsync(id);
        if (testimonial is null)
        {
            TempData["ErrorMessage"] = "Review not found.";
            return RedirectToAction(nameof(Index));
        }

        testimonial.IsActive = !testimonial.IsActive;
        var result = await _testimonialService.UpdateTestimonialAsync(testimonial);
        if (result)
        {
            TempData["SuccessMessage"] = testimonial.IsActive
                ? $"Endorsement from '{testimonial.ClientName}' has been APPROVED and published live."
                : $"Endorsement from '{testimonial.ClientName}' is now SUSPENDED / PENDING APPROVAL.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to update review status.";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var testimonial = await _testimonialService.GetTestimonialByIdAsync(id);
            if (testimonial != null && !string.IsNullOrEmpty(testimonial.ClientImageUrl))
            {
                await _imageService.DeleteImageAsync(testimonial.ClientImageUrl);
            }

            var result = await _testimonialService.DeleteTestimonialAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Review has been deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete review.";
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error: {ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }
}
