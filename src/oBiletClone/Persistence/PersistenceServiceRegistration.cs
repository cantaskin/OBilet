using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IBusRepository, BusRepository>();
        services.AddScoped<IBusServiceRepository, BusServiceRepository>();
        services.AddScoped<IPersonelRepository, PersonelRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IStationRepository, StationRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ICampaignRepository, CampaignRepository>();
        services.AddScoped<IBusServiceStationRepository, BusServiceStationRepository>();
        return services;
    }
}
