using ExcursaoApp.Persistence.Context;

namespace ExcursaoApp.Persistence.UoW;

public sealed class UnitOfWork(IExcursaoAppContext context) : IUnitOfWork
{
    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => context.SaveChangesAsync(cancellationToken);

    public void Rollback()
        => context.ClearChangeTracker();
}