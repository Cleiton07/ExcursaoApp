using FluentValidation.Results;

namespace ExcursaoApp.Domain.Notifications;

public interface INotificationsManager
{
    IReadOnlyCollection<ValidationFailure> FieldNotifications { get; }
    bool HasNotification { get; }
    IReadOnlyCollection<string> NotificationsWithoutField { get; }

    bool AddNotifications(Notifiable notifiable);

    Task<bool> AddNotificationsAsync(Notifiable notifiable, CancellationToken cancellationToken = default);

    bool AddNotificationWithoutField(string notification);
}