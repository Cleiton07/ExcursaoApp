using ExcursaoApp.Database.Context;
using ExcursaoApp.Database.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.Database;

public static class Bootstrapper
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<IExcursaoAppContext, ExcursaoAppContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IApplicationBuilder StartDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<IExcursaoAppContext>();
        context.ApplyMigrations();

        return app;
    }
}