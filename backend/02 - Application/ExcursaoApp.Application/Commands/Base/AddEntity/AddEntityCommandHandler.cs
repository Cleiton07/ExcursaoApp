using ExcursaoApp.Domain.Entities.Base;
using ExcursaoApp.Domain.Notifications;
using ExcursaoApp.Domain.Repositories.Base;
using ExcursaoApp.Persistence.UoW;

namespace ExcursaoApp.Application.Commands.Base.AddEntity;

public abstract class AddEntityCommandHandler<TCommand, TEntity>(INotificationsManager notificationsManager, IRepository<TEntity> repository, IUnitOfWork unitOfWork) : CommandHandler<TCommand, Guid?>
    where TEntity : Entity
    where TCommand : AddEntityCommand<TEntity>
{
    public override async Task<Guid?> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var entity = request.ToEntity();

        if (!await notificationsManager.AddNotificationsAsync(entity, cancellationToken))
            return null;

        await repository.AddAsync(entity);
        await unitOfWork.CommitAsync(cancellationToken);

        return entity.Id;
    }
}