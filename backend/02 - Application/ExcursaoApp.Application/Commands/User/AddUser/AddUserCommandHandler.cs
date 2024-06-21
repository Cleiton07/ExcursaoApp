using ExcursaoApp.Application.Commands.Base.AddEntity;
using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Notifications;
using ExcursaoApp.Domain.Repositories;
using ExcursaoApp.Persistence.UoW;

namespace ExcursaoApp.Application.Commands.User.AddUser;

public sealed class AddUserCommandHandler(INotificationsManager notificationsManager, IUserRepository repository, IUnitOfWork unitOfWork)
    : AddEntityCommandHandler<AddUserCommand, UserEntity>(notificationsManager, repository, unitOfWork)
{
}