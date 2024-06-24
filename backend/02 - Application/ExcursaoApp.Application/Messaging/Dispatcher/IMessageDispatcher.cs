using ExcursaoApp.Application.Commands.Base;
using ExcursaoApp.Application.Queries.Abstractions;

namespace ExcursaoApp.Application.Messaging.Dispatcher;

public interface IMessageDispatcher
{
    Task<TResult> DispatchCommandAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken = default);

    Task DispatchCommandAsync(Command command, CancellationToken cancellationToken = default);

    Task<TResult> DispatchQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}