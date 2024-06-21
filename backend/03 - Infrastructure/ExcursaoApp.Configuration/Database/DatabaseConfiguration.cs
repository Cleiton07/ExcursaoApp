using Microsoft.Extensions.Configuration;

namespace ExcursaoApp.Configuration.Database;

public class DatabaseConfiguration(IConfiguration configuration) : IDatabaseConfiguration
{
    public string ConnectionString { get; } = configuration.GetConnectionString("Database")!;
}