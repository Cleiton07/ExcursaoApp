using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Repositories.Base;

namespace ExcursaoApp.Domain.Repositories;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<bool> AnyByEmailAsync(string email, CancellationToken cancellationToken = default);
}