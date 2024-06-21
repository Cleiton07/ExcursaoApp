using ExcursaoApp.Application.Commands.Base;

namespace ExcursaoApp.Application.Messaging.Dispatcher;

public interface IMessageDispatcher
{
    Task<TResult> DispatchCommandAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken = default);

    Task DispatchCommandAsync(Command command, CancellationToken cancellationToken = default);
}