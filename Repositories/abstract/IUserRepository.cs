using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Repositories.@abstract;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserByUserNameAsync(string userName);
}
