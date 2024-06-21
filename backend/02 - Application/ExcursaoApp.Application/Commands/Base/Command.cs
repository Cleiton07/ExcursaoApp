using ExcursaoApp.Domain.Notifications;
using MediatR;

namespace ExcursaoApp.Application.Commands.Base;

public abstract class Command : Notifiable, IRequest
{
}

public abstract class Command<TResult> : Notifiable, IRequest<TResult>
{
}