namespace ExcursaoApp.Api.ViewModels;

public class ErrorField(string fieldName, string message)
{
    public string FieldName { get; } = fieldName;
    public string Message { get; } = message;
}