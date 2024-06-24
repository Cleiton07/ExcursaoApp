namespace ExcursaoApp.Api.Authentication.Models;

public class AuthenticationViewModel
{
    public DateTime ExpiresInUtc { get; set; }
    public string Token { get; set; }
    public string UserFullName { get; set; }
}