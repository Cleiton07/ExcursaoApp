using ExcursaoApp.Domain.Notifications;

namespace ExcursaoApp.Api.ViewModels;

public class ViewModel(INotificationsManager notificationsManager)
{
    public IReadOnlyCollection<ErrorField> FieldMessages { get; }
        = notificationsManager?.FieldNotifications.Select(fn => new ErrorField(fn.PropertyName, fn.ErrorMessage)).ToList() ?? [];

    public IReadOnlyDictionary<string, List<string>> FieldMessagesDictionary
        => FieldMessages
            .GroupBy(fm => fm.FieldName)
            .Select(x => new KeyValuePair<string, List<string>>(x.Key, x.Select(fm => fm.Message).ToList()))
            .ToDictionary();

    public IReadOnlyCollection<string> MessagesWithoutField { get; set; } = notificationsManager?.NotificationsWithoutField ?? [];

    public bool Success => FieldMessages.Count == 0 && MessagesWithoutField.Count == 0;

    public void AddError(string error)
        => MessagesWithoutField = [.. MessagesWithoutField, error];
}

public class ViewModel<TResult>(INotificationsManager notificationsManager, TResult result) : ViewModel(notificationsManager)
{
    public TResult Result { get; } = result;
}