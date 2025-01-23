using Application.Data;
using Communication.Integrations;
using Domain.Entities.Address;
using Domain.Entities.Users;
using Infrastructure.Integrations.ViaCep;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Cryptography;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjection {
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddPasswordEncripter(services);    
        AddIntegration(services);    
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<ApplicationDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("Database"))
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IApplicationDbContext>(p => p.GetRequiredService<ApplicationDbContext>());
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped<IUnitOfWork>(p => p.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
    }

    private static void AddPasswordEncripter(IServiceCollection services) {
        services.AddScoped<IPasswordEncripter, Sha512Encripter>();
    }

    private static void AddIntegration(IServiceCollection services)
    {
        services.AddScoped<IViaCepIntegration, ViaCepIntegration>();
    }
}
