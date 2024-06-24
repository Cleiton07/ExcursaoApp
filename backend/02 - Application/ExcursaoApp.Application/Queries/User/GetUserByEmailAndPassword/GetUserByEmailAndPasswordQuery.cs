using ExcursaoApp.Application.Queries.Abstractions;

namespace ExcursaoApp.Application.Queries.User.GetUserByEmailAndPassword;

public class GetUserByEmailAndPasswordQuery : IQuery<GetUserByEmailAndPasswordQueryResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
}