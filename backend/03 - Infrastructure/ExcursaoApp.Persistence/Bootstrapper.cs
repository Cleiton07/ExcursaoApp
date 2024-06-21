using ExcursaoApp.Persistence.Context;
using ExcursaoApp.Persistence.UoW;
using ExcursaoApp.Domain.Repositories;
using ExcursaoApp.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.Persistence;

public static class Bootstrapper
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<IExcursaoAppContext, ExcursaoAppContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IApplicationBuilder StartPersistence(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<IExcursaoAppContext>();
        context.ApplyMigrations();

        return app;
    }
}