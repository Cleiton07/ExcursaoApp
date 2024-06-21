using ExcursaoApp.Domain.Entities.Base;

namespace ExcursaoApp.Domain.Repositories.Base;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task AddAsync(TEntity entity);

    Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default);

    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}