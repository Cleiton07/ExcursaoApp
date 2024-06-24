using ExcursaoApp.Application.Queries.Abstractions;
using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExcursaoApp.Application.Queries.User.GetUserByEmailAndPassword;

public class GetUserByEmailAndPasswordQueryHandler(IExcursaoAppContext context) : IQueryHandler<GetUserByEmailAndPasswordQuery, GetUserByEmailAndPasswordQueryResult>
{
    public Task<GetUserByEmailAndPasswordQueryResult> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        => context.Users
            .Where(user => user.Email == request.Email && user.EncryptedPassword == UserEntity.EncryptPassword(request.Password))
            .Select(user => new GetUserByEmailAndPasswordQueryResult
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                Profile = user.Profile
            })
            .FirstOrDefaultAsync(cancellationToken);
}