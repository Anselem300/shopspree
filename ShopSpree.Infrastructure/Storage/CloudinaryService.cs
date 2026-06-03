using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ShopSpree.Infrastructure.Storage;

public class CloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(
        string cloudName,
        string apiKey,
        string apiSecret)
    {
        var account =
            new Account(cloudName, apiKey, apiSecret);

        _cloudinary = new Cloudinary(account);
    }

    public async Task<string?> UploadImageAsync(
        IFormFile file)
    {
        await using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(
                file.FileName,
                stream)
        };

        var result =
            await _cloudinary.UploadAsync(uploadParams);

        return result.SecureUrl?.ToString();
    }
}