using ExcursaoApp.Api.ViewModels;
using ExcursaoApp.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ExcursaoApp.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var notificationsManager = context.HttpContext.RequestServices.GetRequiredService<INotificationsManager>();
        notificationsManager.AddNotificationWithoutField($"Ocorreu um erro inesperado: {context.Exception.InnerException?.Message ?? context.Exception.Message}");

        var response = new ViewModel(notificationsManager);
        context.Result = new JsonResult(response)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }
}