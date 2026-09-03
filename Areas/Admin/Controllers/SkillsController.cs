using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Areas.Admin.Controllers
{
    public class SkillsController : BaseAdminController
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService ?? throw new ArgumentNullException(nameof(skillService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            var models = skills.Select(s => new SkillListViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Percentage = s.Percentage,
                DisplayOrder = s.DisplayOrder,
                CreatedDate = s.CreatedAt.ToString("MMM dd, yyyy")
            }).ToList();

            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new SkillCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var skill = new Skill
            {
                Name = model.Name,
                Percentage = model.Percentage,
                DisplayOrder = model.DisplayOrder,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                var skillId = await _skillService.CreateSkillAsync(skill);
                if (skillId > 0)
                {
                    TempData["SuccessMessage"] = "Skill has been added successfully.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Failed to add skill.";
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
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill is null)
            {
                TempData["ErrorMessage"] = "Skill not found.";
                return RedirectToAction(nameof(Index));
            }

            var model = new SkillEditViewModel
            {
                Id = skill.Id,
                Name = skill.Name,
                Percentage = skill.Percentage,
                DisplayOrder = skill.DisplayOrder
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var skill = await _skillService.GetSkillByIdAsync(model.Id);
            if (skill is null)
            {
                TempData["ErrorMessage"] = "Skill not found.";
                return RedirectToAction(nameof(Index));
            }

            skill.Name = model.Name;
            skill.Percentage = model.Percentage;
            skill.DisplayOrder = model.DisplayOrder;

            try
            {
                var result = await _skillService.UpdateSkillAsync(skill);
                if (result)
                {
                    TempData["SuccessMessage"] = "Skill has been updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["ErrorMessage"] = "Failed to update skill.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _skillService.DeleteSkillAsync(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Skill has been deleted successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete skill.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
