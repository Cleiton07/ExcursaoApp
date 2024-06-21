using ExcursaoApp.Persistence.Context;
using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Repositories;
using ExcursaoApp.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ExcursaoApp.Persistence.Repositories;

public class UserRepository(IExcursaoAppContext context) : Repository<UserEntity>(context), IUserRepository
{
    public Task<bool> AnyByEmailAsync(string email, CancellationToken cancellationToken = default)
        => DbSet.AnyAsync(u => u.Email == email, cancellationToken);
}