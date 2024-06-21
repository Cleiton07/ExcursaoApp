using ExcursaoApp.Domain.Entities.Base;
using ExcursaoApp.Domain.Notifications;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.Domain;

public static class Bootstrapper
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Entity>();
        services.AddScoped<INotificationsManager, NotificationsManager>();

        return services;
    }
}