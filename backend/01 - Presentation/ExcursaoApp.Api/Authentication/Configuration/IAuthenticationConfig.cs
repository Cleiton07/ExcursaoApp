namespace ExcursaoApp.Api.Authentication.Configuration;

public interface IAuthenticationConfig
{
    public string EncryptKey { get; }
    public int ExpirationTimeInHours { get; }
}