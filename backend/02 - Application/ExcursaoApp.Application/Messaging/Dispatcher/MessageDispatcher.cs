using ExcursaoApp.Application.Commands.Base;
using ExcursaoApp.Application.Queries.Abstractions;
using MediatR;

namespace ExcursaoApp.Application.Messaging.Dispatcher;

public sealed class MessageDispatcher(IMediator mediator) : IMessageDispatcher
{
    public Task<TResult> DispatchCommandAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken = default)
        => mediator.Send(command, cancellationToken);

    public Task DispatchCommandAsync(Command command, CancellationToken cancellationToken = default)
        => mediator.Send(command, cancellationToken);

    public Task<TResult> DispatchQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        => mediator.Send(query, cancellationToken);
}