using Application.Services.ImageService;
using Application.Services.LocationService;
using Infrastructure.Adapters.ImageService;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddScoped<HttpClient>();
        services.AddScoped<LocationServiceBase, GoogleLocationServiceAdapter>();

        return services;
    }
}
