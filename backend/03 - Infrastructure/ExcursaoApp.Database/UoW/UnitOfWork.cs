using ExcursaoApp.Database.Context;

namespace ExcursaoApp.Database.UoW;

public sealed class UnitOfWork(IExcursaoAppContext context) : IUnitOfWork
{
    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => context.SaveChangesAsync(cancellationToken);

    public void Rollback()
        => context.ClearChangeTracker();
}