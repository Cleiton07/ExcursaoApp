using ExcursaoApp.Api.Authentication.Models;
using ExcursaoApp.Api.Authentication.Service;
using ExcursaoApp.Api.Controllers.Base;
using ExcursaoApp.Api.ViewModels;
using ExcursaoApp.Application.Messaging.Dispatcher;
using ExcursaoApp.Application.Queries.User.GetUserByEmailAndPassword;
using ExcursaoApp.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace ExcursaoApp.Api.Controllers;

[Route("api/authentication")]
public class AuthenticationController(
    INotificationsManager notificationsManager,
    IMessageDispatcher messageDispatcher,
    IAuthenticationService authenticationService) : ApiController(notificationsManager, messageDispatcher)
{
    [HttpPost]
    public Task<ActionResult<ViewModel<AuthenticationViewModel>>> GenerateTokenAsync([FromBody] GetUserByEmailAndPasswordQuery input)
        => ExecuteAsync(() => authenticationService.AuthenticateAsync(input));
}