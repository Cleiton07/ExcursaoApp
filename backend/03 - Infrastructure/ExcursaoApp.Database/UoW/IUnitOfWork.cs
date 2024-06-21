namespace ExcursaoApp.Database.UoW;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);

    void Rollback();
}