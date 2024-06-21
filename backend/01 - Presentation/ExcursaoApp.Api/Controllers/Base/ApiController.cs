using ExcursaoApp.Api.ViewModels;
using ExcursaoApp.Application.Commands.Base;
using ExcursaoApp.Application.Messaging.Dispatcher;
using ExcursaoApp.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace ExcursaoApp.Api.Controllers.Base;

[ApiController]
public abstract class ApiController(INotificationsManager notificationsManager, IMessageDispatcher messageDispatcher) : ControllerBase
{
    protected Task<ActionResult<ViewModel<TResult>>> ExecuteCommandAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken = default)
        => ExecuteAsync(() => messageDispatcher.DispatchCommandAsync(command, cancellationToken));

    protected Task<ActionResult<ViewModel>> ExecuteCommandAsync(Command command, CancellationToken cancellationToken = default)
        => ExecuteAsync(() => messageDispatcher.DispatchCommandAsync(command, cancellationToken));

    private async Task<ActionResult<ViewModel>> ExecuteAsync(Func<Task> func)
    {
        await func();
        var vm = new ViewModel(notificationsManager);
        return HandleResult(vm);
    }

    private async Task<ActionResult<ViewModel<TResult>>> ExecuteAsync<TResult>(Func<Task<TResult>> func)
    {
        var result = await func();
        var vm = new ViewModel<TResult>(notificationsManager, result);
        return HandleResult(vm);
    }

    private ActionResult<TViewModel> HandleResult<TViewModel>(TViewModel vm) where TViewModel : ViewModel
    {
        if (vm.Success)
            return Ok(vm);

        return BadRequest(vm);
    }
}