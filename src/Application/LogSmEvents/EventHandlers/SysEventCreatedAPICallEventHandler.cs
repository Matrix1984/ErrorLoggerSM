using ErrorLoggerSM.Application.SysErrors.EventHandlers;
using ErrorLoggerSM.Domain.Events.SysErrorEvents;
using Microsoft.Extensions.Logging;

namespace ErrorLoggerSM.Application.LogSmEvents.EventHandlers;
public class SysEventCreatedAPICallEventHandler : INotificationHandler<SysErrorCreatedAPICallEvent>
{
    private readonly ILogger<SysErrorCreatedAPIEmailHandler> _logger;

    public SysEventCreatedAPICallEventHandler(ILogger<SysErrorCreatedAPIEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SysErrorCreatedAPICallEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ErrorLoggerSM Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
} 
