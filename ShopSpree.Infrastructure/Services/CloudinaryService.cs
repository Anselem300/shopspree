using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ShopSpree.Core.Interfaces;

namespace ShopSpree.Infrastructure.Services;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(
        Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<string> UploadImageAsync(
        Stream fileStream,
        string fileName)
    {
        var uploadParams =
            new ImageUploadParams
            {
                File = new FileDescription(
                    fileName,
                    fileStream)
            };

        var result =
            await _cloudinary.UploadAsync(
                uploadParams);

        return result.SecureUrl.ToString();
    }
}