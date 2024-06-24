using ExcursaoApp.Domain.Enums;

namespace ExcursaoApp.Application.Abstractions.Providers;

public interface IAuthenticationProvider
{
    DateTime? AuthenticatedAtUtc { get; }
    DateTime? ExpiresInUtc { get; }
    bool IsAuthenticated { get; }
    string UserEmail { get; }
    Guid? UserId { get; }
    UserProfile UserProfile { get; }
}