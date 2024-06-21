using FluentValidation;
using FluentValidation.Results;

namespace ExcursaoApp.Domain.Notifications;

public abstract class Notifiable(IValidator? validator = null)
{
    internal ValidationResult Validate()
    {
        if (validator is null)
            return CreateEmptyValidationResult();

        return validator.Validate(CreateValidationContext());
    }

    internal async Task<ValidationResult> ValidateAsync(CancellationToken cancellationToken = default)
    {
        if (validator is null)
            return CreateEmptyValidationResult();

        return await validator.ValidateAsync(CreateValidationContext(), cancellationToken);
    }

    private static ValidationResult CreateEmptyValidationResult()
        => new() { Errors = [] };

    private IValidationContext? CreateValidationContext()
    {
        var validationContextType = typeof(ValidationContext<>).MakeGenericType(GetType());
        var validationContext = (IValidationContext?)Activator.CreateInstance(validationContextType, this);
        return validationContext;
    }
}