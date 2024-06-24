using ExcursaoApp.Api.Authentication.Configuration;
using ExcursaoApp.Api.Authentication.Models;
using ExcursaoApp.Application.Messaging.Dispatcher;
using ExcursaoApp.Application.Queries.User.GetUserByEmailAndPassword;
using ExcursaoApp.Domain.Notifications;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExcursaoApp.Api.Authentication.Service;

public class AuthenticationService(IAuthenticationConfig authenticationConfig, IMessageDispatcher dispatcher, INotificationsManager notificationsManager) : IAuthenticationService
{
    public async Task<AuthenticationViewModel> AuthenticateAsync(GetUserByEmailAndPasswordQuery input)
    {
        var userInfo = await dispatcher.DispatchQueryAsync(input);
        if (userInfo is null)
        {
            notificationsManager.AddNotificationWithoutField("Email ou senha inválidos");
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(authenticationConfig.EncryptKey);

        var authenticatedAt = DateTime.UtcNow;
        var expiresIn = authenticatedAt.AddHours(authenticationConfig.ExpirationTimeInHours);
        var tokenDecryptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                new Claim(ClaimTypes.Name, userInfo.FullName),
                new Claim(ClaimTypes.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.Profile.ToString()),
                new Claim(AuthenticationConstants.ExpiresInUtcClaimName, expiresIn.ToString()),
                new Claim(AuthenticationConstants.AuthenticatedAtUtcClaimName, authenticatedAt.ToString())
            ]),
            Expires = expiresIn,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDecryptor);
        string strToken = tokenHandler.WriteToken(token);

        return new()
        {
            ExpiresInUtc = expiresIn,
            Token = strToken,
            UserFullName = userInfo.FullName,
        };
    }
}