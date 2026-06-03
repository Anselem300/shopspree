using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopSpree.Application.Interfaces;
using ShopSpree.Application.Services;
using ShopSpree.Infrastructure.Authentication;
using ShopSpree.Infrastructure.Data;
using ShopSpree.Infrastructure.Data.Repositories;

namespace ShopSpree.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<MongoContext>();

        services.AddHttpContextAccessor();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBusinessRepository, BusinessRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBusinessService, BusinessService>();
        services.AddScoped<IReviewService, ReviewService>();

        services.AddScoped<IAuthenticateService,
            CustomAuthenticationService>();

        return services;
    }
}