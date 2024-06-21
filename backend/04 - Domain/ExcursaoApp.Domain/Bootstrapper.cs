using ExcursaoApp.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.Domain;

public static class Bootstrapper
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<INotificationsManager, NotificationsManager>();

        return services;
    }
}