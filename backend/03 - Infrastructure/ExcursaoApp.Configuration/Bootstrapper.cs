using ExcursaoApp.Configuration.Database;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseConfiguration, DatabaseConfiguration>();

        return services;
    }
}