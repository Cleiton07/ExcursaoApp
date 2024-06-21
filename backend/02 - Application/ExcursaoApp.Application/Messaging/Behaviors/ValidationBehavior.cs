using ExcursaoApp.Domain.Notifications;
using MediatR;

namespace ExcursaoApp.Application.Messaging.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(INotificationsManager notificationsManager) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is Notifiable command && !await notificationsManager.AddNotificationsAsync(command, cancellationToken))
            return default;

        return await next();
    }
}