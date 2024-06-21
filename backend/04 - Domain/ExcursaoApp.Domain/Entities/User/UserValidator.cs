using ExcursaoApp.Domain.Enums;
using FluentValidation;

namespace ExcursaoApp.Domain.Entities.User;

internal class UserValidator : AbstractValidator<UserEntity>
{
    public const string EmailInvalidErrorMessage = "Email inválido";
    public const string EmailIsRequiredErrorMessage = "O email é obrigatório";
    public const string EncryptedPasswordIsRequiredErrorMessage = "A senha é obrigatória";
    public const string FullNameInvalidErrorMessage = "O nome deve conter o sobrenome e ter no mínimo dois caracteres";
    public const string FullNameIsRequiredErrorMessage = "O nome é obrigatório";
    public const string PhoneNumberInvalidErrorMessage = "Número de telefone inválido";
    public const string PhoneNumberIsRequiredErrorMessage = "O número de telefone é obrigatório";
    public const string ProfileInvalidErrorMessage = "O perfil de usuário é inválido";
    public static readonly string EmailMaxLengthErrorMessage = $"O email deve conter no máximo {UserEntity.EmailMaxLength} caracteres";
    public static readonly string FullNameMaxLengthErrorMessage = $"O nome deve conter no máximo {UserEntity.FullNameMaxLength} caracteres";

    public UserValidator()
    {
        ApplyRulesToEmail();
        ApplyRulesToEncryptedPassword();
        ApplyRulesToPhoneNumber();
        ApplyRulesToFullName();
        ApplyRulesToProfile();
    }

    private void ApplyRulesToEmail()
    {
        RuleFor(u => u.Email).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(EmailIsRequiredErrorMessage)
            .EmailAddress().WithMessage(EmailInvalidErrorMessage);
    }

    private void ApplyRulesToEncryptedPassword()
    {
        RuleFor(u => u.EncryptedPassword).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(EncryptedPasswordIsRequiredErrorMessage);
    }

    private void ApplyRulesToFullName()
    {
        RuleFor(u => u.FullName).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(FullNameIsRequiredErrorMessage)
            .Must(fn => fn.Split(' ').Length >= UserEntity.FullNameMinNames).WithMessage(FullNameInvalidErrorMessage)
            .Must(fn => fn.Split(' ').First().Length > UserEntity.NameMinLength).WithMessage(FullNameInvalidErrorMessage)
            .MaximumLength(UserEntity.FullNameMaxLength).WithMessage(FullNameMaxLengthErrorMessage);
    }

    private void ApplyRulesToPhoneNumber()
    {
        RuleFor(u => u.PhoneNumber).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(PhoneNumberIsRequiredErrorMessage)
            .Must(pn => pn.All(char.IsNumber)).WithMessage(PhoneNumberInvalidErrorMessage)
            .MinimumLength(10).WithMessage(PhoneNumberInvalidErrorMessage)
            .MinimumLength(11).WithMessage(PhoneNumberInvalidErrorMessage);
    }

    private void ApplyRulesToProfile()
    {
        RuleFor(u => u.Profile).Cascade(CascadeMode.Stop)
            .Must(p => Enum.GetValues<UserProfile>().Contains(p)).WithMessage(ProfileInvalidErrorMessage);
    }
}