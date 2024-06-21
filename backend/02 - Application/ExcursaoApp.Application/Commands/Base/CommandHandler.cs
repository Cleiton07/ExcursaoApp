using MediatR;

namespace ExcursaoApp.Application.Commands.Base
{
    public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : Command
    {
        public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : Command<TResult>
    {
        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}