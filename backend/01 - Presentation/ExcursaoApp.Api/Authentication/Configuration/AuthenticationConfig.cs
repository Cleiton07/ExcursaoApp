namespace ExcursaoApp.Api.Authentication.Configuration;

public class AuthenticationConfig : IAuthenticationConfig
{
    public AuthenticationConfig(IConfiguration configuration)
    {
        var authenticationConfigSection = configuration.GetSection(nameof(AuthenticationConfig));

        EncryptKey = authenticationConfigSection[nameof(EncryptKey)];
        ExpirationTimeInHours = int.Parse(authenticationConfigSection[nameof(ExpirationTimeInHours)]);
    }

    public string EncryptKey { get; }
    public int ExpirationTimeInHours { get; }
}