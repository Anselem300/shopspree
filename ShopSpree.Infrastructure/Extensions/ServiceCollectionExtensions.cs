using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopSpree.Infrastructure.Configurations;
using ShopSpree.Infrastructure.Data;
using ShopSpree.Core.Interfaces;
using ShopSpree.Infrastructure.Repositories;
using ShopSpree.Infrastructure.Services;

namespace ShopSpree.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(
            configuration.GetSection(
                MongoDbSettings.SectionName));

        services.Configure<CloudinarySettings>(
            configuration.GetSection(
                CloudinarySettings.SectionName));

        services.AddSingleton<MongoDbContext>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IBusinessRepository, BusinessRepository>();

        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<ICloudinaryService, CloudinaryService>();

        services.AddScoped<IUserService, AuthService>();
        services.AddScoped<IBusinessService, BusinessService>();

        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IReviewService, ReviewService>();

        services.AddSingleton(provider =>
        {
            var settings =
                configuration
                .GetSection(CloudinarySettings.SectionName)
                .Get<CloudinarySettings>()!;

            var account = new Account(
                settings.CloudName,
                settings.ApiKey,
                settings.ApiSecret);

            return new Cloudinary(account);
        });

        return services;
    }
}