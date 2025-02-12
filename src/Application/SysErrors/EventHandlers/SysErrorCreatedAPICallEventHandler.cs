using ErrorLoggerSM.Domain.Events;
using Microsoft.Extensions.Logging;

namespace ErrorLoggerSM.Application.SysErrors.EventHandlers;

public class SysErrorCreatedAPICallEventHandler : INotificationHandler<SysErrorCreatedAPICallEvent>
{
    private readonly ILogger<SysErrorCreatedAPIEmailHandler> _logger;

    public SysErrorCreatedAPICallEventHandler(ILogger<SysErrorCreatedAPIEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SysErrorCreatedAPICallEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ErrorLoggerSM Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
