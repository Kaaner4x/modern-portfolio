using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Services.@abstract;

public interface IUserService
{
    Task<User?> GetUserByUserNameAsync(string userName);
    Task<User?> GetUserByIdAsync(int id);
    Task<bool> ValidatePasswordAsync(string userName, string password);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> UpdatePasswordAsync(int userId, string newPassword);
}
