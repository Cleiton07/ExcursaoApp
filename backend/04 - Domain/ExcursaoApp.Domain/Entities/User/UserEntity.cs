using ExcursaoApp.Domain.Entities.Base;
using ExcursaoApp.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace ExcursaoApp.Domain.Entities.User;

public class UserEntity(UserProfile profile) : Entity
{
    public const int EmailMaxLength = 60;
    public const int FullNameMaxLength = 60;
    public const int FullNameMinNames = 2;
    public const int NameMinLength = 2;
    public const int PhoneNumberMaxLength = 11;
    public const int PhoneNumberMinLength = 10;

    public string Email { get; private set; } = "";
    public string EncryptedPassword { get; private set; } = "";
    public string FullName { get; private set; } = "";
    public string PhoneNumber { get; private set; } = "";
    public UserProfile Profile { get; set; } = profile;

    public static string EncryptPassword(string text)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(text);
        byte[] hash = MD5.HashData(inputBytes);

        var sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
            sb.Append(hash[i].ToString("X2"));

        return sb.ToString();
    }

    public UserEntity SetEmail(string email)
    {
        Email = email.Trim();
        return this;
    }

    public UserEntity SetFullName(string fullName)
    {
        FullName = fullName.Trim();
        return this;
    }

    public UserEntity SetPassword(string password)
    {
        EncryptedPassword = EncryptPassword(password);
        return this;
    }

    public UserEntity SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber.Trim();
        return this;
    }
}