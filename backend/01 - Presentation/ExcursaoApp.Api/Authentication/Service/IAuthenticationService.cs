using ExcursaoApp.Api.Authentication.Models;
using ExcursaoApp.Application.Queries.User.GetUserByEmailAndPassword;

namespace ExcursaoApp.Api.Authentication.Service;

public interface IAuthenticationService
{
    Task<AuthenticationViewModel> AuthenticateAsync(GetUserByEmailAndPasswordQuery input);
}