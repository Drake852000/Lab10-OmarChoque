using Lab10_OmarChoque.Domain.Interfaces;
using Lab10_OmarChoque.Infrastructure.Persistence;
using Lab10_OmarChoque.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab10_OmarChoque.Infrastructure.Configuration;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database Connection
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString =
                configuration.GetConnectionString("DefaultConnection");

            options.UseNpgsql(connectionString);
        });

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ITicketRepository, TicketRepository>();
        
        services.AddScoped<IResponseRepository, ResponseRepository>();
        
        return services;
    }
}