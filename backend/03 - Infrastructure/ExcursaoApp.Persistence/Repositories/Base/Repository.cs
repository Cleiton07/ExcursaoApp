using ExcursaoApp.Domain.Entities.Base;
using ExcursaoApp.Domain.Repositories.Base;
using ExcursaoApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExcursaoApp.Persistence.Repositories.Base;

public abstract class Repository<TEntity>(IExcursaoAppContext context) : IRepository<TEntity>
    where TEntity : Entity
{
    protected DbSet<TEntity> DbSet { get; } = context.Set<TEntity>();

    public async Task AddAsync(TEntity entity)
        => await DbSet.AddAsync(entity);

    public Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default)
        => DbSet.AnyAsync(e => e.Id == id, cancellationToken);

    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
}