using ExcursaoApp.Configuration.Database;
using ExcursaoApp.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ExcursaoApp.Database.Context;

public class ExcursaoAppContext(IDatabaseConfiguration configuration) : DbContext(BuildOptions(configuration)), IExcursaoAppContext
{
    public DbSet<UserEntity> Users { get; set; }

    public void ApplyMigrations()
    {
        if (Database.GetPendingMigrations().Any())
            Database.Migrate();
    }

    public void ClearChangeTracker()
        => ChangeTracker.Clear();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private static DbContextOptions<ExcursaoAppContext> BuildOptions(IDatabaseConfiguration configuration)
             => new DbContextOptionsBuilder<ExcursaoAppContext>()
            .UseSqlServer(configuration.ConnectionString)
            .Options;
}