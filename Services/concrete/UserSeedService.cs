using System;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using ModernPortfolio.Services.@abstract;

namespace ModernPortfolio.Services.concrete;

public class UserSeedService : IUserSeedService
{
    private readonly IUserRepository _userRepository;

    public UserSeedService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }
    
    public async Task SeedDefaultUserAsync()
    {
        var allUsers = await _userRepository.GetAllAsync();
        if(!allUsers.Any())
        {
            var defaultUser = new User
            {
                UserName = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123!"),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
            await _userRepository.CreateAsync(defaultUser);
        }
    }
}
