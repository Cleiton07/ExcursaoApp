using ExcursaoApp.Domain.Enums;

namespace ExcursaoApp.Application.Queries.User.GetUserByEmailAndPassword;

public class GetUserByEmailAndPasswordQueryResult
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public Guid Id { get; set; }
    public UserProfile Profile { get; set; }
}