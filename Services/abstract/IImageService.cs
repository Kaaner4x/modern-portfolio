using Microsoft.AspNetCore.Http;

namespace ModernPortfolio.Services.@abstract;

public interface IImageService
{
    Task<string> SaveImageAsync(IFormFile imageFile, string folderName = "portfolio");
    Task DeleteImageAsync(string imageUrl);
}
