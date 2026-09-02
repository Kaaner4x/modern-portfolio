using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Services.@abstract;
using ModernPortfolio.ViewModels;

namespace ModernPortfolio.Areas.Admin.Controllers
{
    public class SettingsController : BaseAdminController
    {
        private readonly IUserService _userService;

        public SettingsController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentLoggedInUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new SettingsViewModel
            {
                Id = user.Id,
                UserName = user.UserName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsername(SettingsViewModel model)
        {
            var user = await GetCurrentLoggedInUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (string.IsNullOrWhiteSpace(model.UserName))
            {
                TempData["ErrorMessage"] = "Username cannot be empty.";
                return RedirectToAction(nameof(Index));
            }

            if (model.UserName.Length < 3 || model.UserName.Length > 50)
            {
                TempData["ErrorMessage"] = "Username must be between 3 and 50 characters.";
                return RedirectToAction(nameof(Index));
            }

            // If same username
            if (string.Equals(user.UserName, model.UserName, StringComparison.OrdinalIgnoreCase))
            {
                TempData["InfoMessage"] = "Username is already up to date.";
                return RedirectToAction(nameof(Index));
            }

            // Check if username is taken by another user
            var existingUser = await _userService.GetUserByUserNameAsync(model.UserName);
            if (existingUser != null && existingUser.Id != user.Id)
            {
                TempData["ErrorMessage"] = "This username is already taken by another user.";
                return RedirectToAction(nameof(Index));
            }

            user.UserName = model.UserName;
            var isUpdated = await _userService.UpdateUserAsync(user);

            if (isUpdated)
            {
                // Refresh authentication claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                TempData["SuccessMessage"] = "Username updated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "An error occurred while updating the username.";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(SettingsViewModel model)
        {
            var user = await GetCurrentLoggedInUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (string.IsNullOrWhiteSpace(model.CurrentPassword))
            {
                TempData["PasswordErrorMessage"] = "Please enter your current password.";
                return RedirectToAction(nameof(Index));
            }

            if (string.IsNullOrWhiteSpace(model.NewPassword) || model.NewPassword.Length < 6)
            {
                TempData["PasswordErrorMessage"] = "New password must be at least 6 characters.";
                return RedirectToAction(nameof(Index));
            }

            if (model.NewPassword != model.ConfirmNewPassword)
            {
                TempData["PasswordErrorMessage"] = "The new password and confirmation password do not match.";
                return RedirectToAction(nameof(Index));
            }

            // Verify current password
            var isCurrentPasswordValid = await _userService.ValidatePasswordAsync(user.UserName, model.CurrentPassword);
            if (!isCurrentPasswordValid)
            {
                TempData["PasswordErrorMessage"] = "The current password you entered is incorrect!";
                return RedirectToAction(nameof(Index));
            }

            // Update password
            var isUpdated = await _userService.UpdatePasswordAsync(user.Id, model.NewPassword);
            if (isUpdated)
            {
                TempData["PasswordSuccessMessage"] = "Password updated successfully.";
            }
            else
            {
                TempData["PasswordErrorMessage"] = "An error occurred while updating the password.";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<ModernPortfolio.Models.User?> GetCurrentLoggedInUserAsync()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdClaim, out var userId))
            {
                return await _userService.GetUserByIdAsync(userId);
            }

            if (!string.IsNullOrEmpty(User.Identity?.Name))
            {
                return await _userService.GetUserByUserNameAsync(User.Identity.Name);
            }

            return null;
        }
    }
}
