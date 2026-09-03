using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Areas.Admin.Controllers;

public class ContactsController : BaseAdminController
{
    private readonly IContactService _contactService;

    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        var model = contacts.Select(c => new ContactListViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            Subject = c.Subject,
            Message = c.Message,
            CreatedAt = c.CreatedAt,
            IsRead = c.IsRead
        }).ToList();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var result = await _contactService.MarkAsReadAsync(id);
        if (result)
        {
            TempData["SuccessMessage"] = "Message marked as read.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to update message status.";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var result = await _contactService.DeleteContactAsync(id);
        if (result)
        {
            TempData["SuccessMessage"] = "Message deleted successfully.";
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to delete message.";
        }

        return RedirectToAction(nameof(Index));
    }
}
