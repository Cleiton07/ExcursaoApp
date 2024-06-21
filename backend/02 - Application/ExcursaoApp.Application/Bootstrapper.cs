using ExcursaoApp.Application.Commands.Base;
using ExcursaoApp.Application.Messaging.Behaviors;
using ExcursaoApp.Application.Messaging.Dispatcher;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExcursaoApp.Application;

public static class Bootstrapper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Command>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblyContaining<Command>();
            opt.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddTransient<IMessageDispatcher, MessageDispatcher>();

        return services;
    }
}