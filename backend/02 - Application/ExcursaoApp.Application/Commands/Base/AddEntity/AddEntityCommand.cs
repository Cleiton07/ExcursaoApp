using ExcursaoApp.Domain.Entities.Base;

namespace ExcursaoApp.Application.Commands.Base.AddEntity
{
    public abstract class AddEntityCommand<TEntity> : Command<Guid?>
        where TEntity : Entity
    {
        public abstract TEntity ToEntity();
    }
}