using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ModernPortfolio.Services.@abstract;

namespace ModernPortfolio.Services.concrete;

public class ImageService : IImageService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
    private static readonly string[] AllowedMimeTypes = { "image/jpeg", "image/png", "image/webp", "image/gif", "image/pjpeg", "image/x-png" };
    private const long MaxFileSize = 5 * 1024 * 1024; // 5MB

    public ImageService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
    }

    public async Task<string> SaveImageAsync(IFormFile imageFile, string folderName = "portfolio")
    {
        if (imageFile is null || imageFile.Length == 0)
        {
            throw new ArgumentException("Please select a valid image file.", nameof(imageFile));
        }

        if (imageFile.Length > MaxFileSize)
        {
            throw new ArgumentException("Image size cannot exceed 5MB.");
        }

        var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (string.IsNullOrEmpty(fileExtension) || !AllowedExtensions.Contains(fileExtension))
        {
            throw new ArgumentException("Invalid file format. Only JPG, JPEG, PNG, WEBP, and GIF formats are allowed.");
        }

        if (!string.IsNullOrEmpty(imageFile.ContentType) && !AllowedMimeTypes.Contains(imageFile.ContentType.ToLowerInvariant()))
        {
            throw new ArgumentException("Invalid file content type.");
        }

        // Sanitize folder name (allow only alphanumeric characters and underscores)
        var sanitizedFolderName = new string(folderName.Where(char.IsLetterOrDigit).ToArray());
        if (string.IsNullOrEmpty(sanitizedFolderName))
        {
            sanitizedFolderName = "uploads";
        }

        var fileName = $"{Guid.NewGuid():N}{fileExtension}";
        var rootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var uploadsFolder = Path.Combine(rootPath, "ui", "img", sanitizedFolderName);

        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var filePath = Path.Combine(uploadsFolder, fileName);

        // Ensure target path is safely within the uploads folder
        var fullPath = Path.GetFullPath(filePath);
        if (!fullPath.StartsWith(Path.GetFullPath(uploadsFolder), StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Invalid upload path.");
        }

        await using var stream = new FileStream(filePath, FileMode.Create);
        await imageFile.CopyToAsync(stream);

        return $"ui/img/{sanitizedFolderName}/{fileName}";
    }

    public async Task DeleteImageAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            return;
        }

        var normalizedUrl = imageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
        var rootPath = _webHostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var filePath = Path.Combine(rootPath, normalizedUrl);

        var fullPath = Path.GetFullPath(filePath);
        // Security check: ensure path is inside WebRootPath to prevent path traversal
        if (!fullPath.StartsWith(Path.GetFullPath(rootPath), StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (File.Exists(fullPath))
        {
            await Task.Run(() => File.Delete(fullPath));
        }
    }
}
