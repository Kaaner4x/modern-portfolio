using System;
using System.Text.RegularExpressions;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;
using ModernPortfolio.Services.@abstract;

namespace ModernPortfolio.Services.concrete;

public class ContactService : IContactService
{
     private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<int> CreateContactAsync(Contact contact)
    {
        if (contact is null)
        {
            throw new ArgumentNullException("Contact cannot be null!", nameof(contact));
        }
        ValidateContact(contact);
        contact.CreatedAt = DateTime.UtcNow;
        contact.IsRead = false;
        contact.Email = contact.Email.Trim().ToLowerInvariant();
        contact.Name = contact.Name.Trim();
        if (!string.IsNullOrWhiteSpace(contact.Subject)) contact.Subject = contact.Subject.Trim();
        contact.Message = contact.Message.Trim();
        var result = await _repository.CreateAsync(contact);
        return result;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        var contacts = await _repository.GetAllAsync();
        var result = contacts.OrderByDescending(c => c.CreatedAt);
        return result;
    }

    public async Task<Contact?> GetContactByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Contact ID must be greater than zero!", nameof(id));
        }
        var result = await _repository.GetByIdAsync(id);
        return result;
    }

    public async Task<IEnumerable<Contact>> GetUnreadContactsAsync()
    {
        var contacts = await _repository.GetUnreadMessagesAsync();
        var result = contacts.OrderByDescending(c => c.CreatedAt);
        return result;
    }

    public async Task<bool> MarkAsReadAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Contact ID must be greater than zero!", nameof(id));
        }
        var contact = await _repository.GetByIdAsync(id);
        if (contact is null)
        {
            throw new InvalidOperationException($"Contact with Id {id} not found");
        }
        if (contact.IsRead)
        {
            return true;
        }
        contact.IsRead = true;
        var result = await _repository.UpdateAsync(contact);
        return result;
    }

    private void ValidateContact(Contact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.Name))
        {
            throw new ArgumentException("Name cannot be emtpy or whitespace!", nameof(contact));
        }
        if (contact.Name.Length > 100)
        {
            throw new ArgumentException("Name cannot exceed 100 characters!", nameof(contact));
        }
        if (!IsValidEmail(contact.Email))
        {
            throw new ArgumentException("Email format is invalid!", nameof(contact));
        }
        if (!string.IsNullOrWhiteSpace(contact.Subject) && contact.Subject.Length > 200)
        {
            throw new ArgumentException("Subject cannot exceed 200 characters!", nameof(contact));
        }
        if (string.IsNullOrWhiteSpace(contact.Message))
        {
            throw new ArgumentException("Message cannot be emtpy or whitespace!", nameof(contact));
        }
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }
        if (email.Length > 255)
        {
            return false;
        }
        try
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }
        catch
        {
            return false;
        }
    }
}
