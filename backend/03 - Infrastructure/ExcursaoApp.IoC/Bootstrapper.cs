using ExcursaoApp.Application;
using ExcursaoApp.Configuration;
using ExcursaoApp.Domain;
using ExcursaoApp.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.IoC;

public static class Bootstrapper
{
    public static IServiceCollection AddExcursaoApp(this IServiceCollection services)
        => services
            .AddDomain()
            .AddConfiguration()
            .AddPersistence()
            .AddApplication();

    public static IApplicationBuilder StartExcursaoApp(this IApplicationBuilder app)
        => app.StartPersistence();
}