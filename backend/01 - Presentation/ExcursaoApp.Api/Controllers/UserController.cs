using ExcursaoApp.Api.Controllers.Base;
using ExcursaoApp.Api.ViewModels;
using ExcursaoApp.Application.Commands.User.AddUser;
using ExcursaoApp.Application.Messaging.Dispatcher;
using ExcursaoApp.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace ExcursaoApp.Api.Controllers;

[Route("api/users")]
public class UserController(INotificationsManager notificationsManager, IMessageDispatcher messageDispatcher) : ApiController(notificationsManager, messageDispatcher)
{
    [HttpPost]
    public Task<ActionResult<ViewModel<Guid?>>> AddUserAsync([FromBody] AddUserCommand command) => ExecuteCommandAsync(command);
}