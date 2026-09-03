using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Services.@abstract;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();
    Task<IEnumerable<Contact>> GetUnreadContactsAsync();
    Task<Contact?> GetContactByIdAsync(int id);
    Task<int> CreateContactAsync(Contact contact);
    Task<bool> MarkAsReadAsync(int id);
    Task<bool> DeleteContactAsync(int id);
}
