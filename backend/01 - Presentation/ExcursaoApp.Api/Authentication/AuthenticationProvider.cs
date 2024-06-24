using ExcursaoApp.Application.Abstractions.Providers;
using ExcursaoApp.Domain.Enums;
using System.Security.Claims;

namespace ExcursaoApp.Api.Authentication;

public class AuthenticationProvider : IAuthenticationProvider
{
    public AuthenticationProvider(IHttpContextAccessor httpContextAccessor)
        => Fill(httpContextAccessor);

    public DateTime? AuthenticatedAtUtc { get; private set; }

    public DateTime? ExpiresInUtc { get; private set; }

    public bool IsAuthenticated { get; private set; }

    public string UserEmail { get; private set; }

    public Guid? UserId { get; private set; }

    public UserProfile UserProfile { get; private set; }

    private void Fill(IHttpContextAccessor httpContextAccessor)
    {
        var userClaims = httpContextAccessor?.HttpContext?.User;

        IsAuthenticated = userClaims?.Identity?.IsAuthenticated is true;
        if (IsAuthenticated)
        {
            UserId = Guid.Parse(userClaims.FindFirstValue(ClaimTypes.NameIdentifier));
            UserEmail = userClaims.FindFirstValue(ClaimTypes.Email);
            AuthenticatedAtUtc = DateTime.Parse(userClaims.FindFirstValue(AuthenticationConstants.AuthenticatedAtUtcClaimName));
            ExpiresInUtc = DateTime.Parse(userClaims.FindFirstValue(AuthenticationConstants.ExpiresInUtcClaimName));
            UserProfile = Enum.Parse<UserProfile>(userClaims.FindFirstValue(ClaimTypes.Role), true);
        }
    }
}