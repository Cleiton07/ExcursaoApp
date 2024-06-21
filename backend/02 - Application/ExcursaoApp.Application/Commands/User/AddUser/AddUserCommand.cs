using ExcursaoApp.Application.Commands.Base.AddEntity;
using ExcursaoApp.Domain.Entities.User;
using ExcursaoApp.Domain.Enums;

namespace ExcursaoApp.Application.Commands.User.AddUser;

public sealed class AddUserCommand : AddEntityCommand<UserEntity>
{
    public string Email { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Password { get; set; } = "";
    public string PasswordConfirmation { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Profile { get; set; } = "";

    public override UserEntity ToEntity()
    {
        Enum.TryParse<UserProfile>(Profile, true, out var profile);
        return new UserEntity(profile)
            .SetEmail(Email)
            .SetFullName(FullName)
            .SetPassword(Password)
            .SetPhoneNumber(string.Join("", PhoneNumber.Where(char.IsNumber)));
    }
}