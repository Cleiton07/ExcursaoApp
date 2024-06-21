using ExcursaoApp.Domain.Repositories;
using FluentValidation;

namespace ExcursaoApp.Application.Commands.User.AddUser;

public sealed class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public const string EmailAlreadyExistsErrorMessage = "O email informado já está sendo utilizado";
    public const string PasswordConfirmationNotEqualsErrorMessage = "A confirmação da senha não corresponde";

    private readonly IUserRepository _userRepository;

    public AddUserCommandValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        ApplyRulesToEmail();
        ApplyRulesToPasswordConfirmation();
    }

    private void ApplyRulesToEmail()
    {
        When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
        {
            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .MustAsync(async (email, ct) => !await _userRepository.AnyByEmailAsync(email, ct)).WithMessage(EmailAlreadyExistsErrorMessage);
        });
    }

    private void ApplyRulesToPasswordConfirmation()
    {
        When(x => !string.IsNullOrWhiteSpace(x.Password), () =>
        {
            RuleFor(x => x.PasswordConfirmation).Cascade(CascadeMode.Stop)
                .Must((command, _, ct) => command.Password.Equals(command.PasswordConfirmation)).WithMessage(PasswordConfirmationNotEqualsErrorMessage);
        });
    }
}