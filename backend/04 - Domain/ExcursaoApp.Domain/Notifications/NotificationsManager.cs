using FluentValidation;
using FluentValidation.Results;

namespace ExcursaoApp.Domain.Notifications;

public class NotificationsManager(IServiceProvider serviceProvider) : INotificationsManager
{
    public IReadOnlyCollection<ValidationFailure> FieldNotifications { get; private set; } = [];

    public bool HasNotification => FieldNotifications.Count > 0 || NotificationsWithoutField.Count > 0;

    public IReadOnlyCollection<string> NotificationsWithoutField { get; private set; } = [];

    public bool AddNotifications(Notifiable notifiable)
    {
        var validationResult = notifiable.Validate();
        return AddNotificationsFromValidationResult(validationResult);
    }

    public async Task<bool> AddNotificationsAsync(Notifiable notifiable, CancellationToken cancellationToken = default)
    {
        var validationResult = await notifiable.ValidateAsync(GetValidator(notifiable), cancellationToken);
        return AddNotificationsFromValidationResult(validationResult);
    }

    public bool AddNotificationWithoutField(string notification)
    {
        if (!string.IsNullOrWhiteSpace(notification))
            NotificationsWithoutField = [.. NotificationsWithoutField, notification];

        return !HasNotification;
    }

    private bool AddNotificationsFromValidationResult(ValidationResult validationResult)
    {
        FieldNotifications = [.. FieldNotifications, .. validationResult.Errors];
        return !HasNotification;
    }

    private IValidator GetValidator(Notifiable notifiable)
    {
        var validatorType = typeof(IValidator<>).MakeGenericType(notifiable.GetType());
        var validator = serviceProvider.GetService(validatorType);
        return (IValidator)validator;
    }
}