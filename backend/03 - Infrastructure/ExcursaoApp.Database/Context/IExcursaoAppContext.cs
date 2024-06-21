using ExcursaoApp.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ExcursaoApp.Database.Context;

public interface IExcursaoAppContext : IDisposable
{
    DbSet<UserEntity> Users { get; set; }

    void ApplyMigrations();

    void ClearChangeTracker();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}