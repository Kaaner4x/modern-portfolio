using System;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;

namespace ModernPortfolio.Repositories.@abstract;

public interface IContactRepository : IGenericRepository<Contact>
{
    Task<IEnumerable<Contact>> GetUnreadMessagesAsync();
}
