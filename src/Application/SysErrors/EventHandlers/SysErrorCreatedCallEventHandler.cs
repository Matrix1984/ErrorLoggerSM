using ErrorLoggerSM.Domain.Events.SysErrorEvents;
using Microsoft.Extensions.Logging;

namespace ErrorLoggerSM.Application.SysErrors.EventHandlers;
public class SysErrorCreatedCallEventHandler : INotificationHandler<SysErrorCreatedEvent>
{
    private readonly ILogger<SysErrorCreatedAPIEmailHandler> _logger;

    public SysErrorCreatedCallEventHandler(ILogger<SysErrorCreatedAPIEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SysErrorCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ErrorLoggerSM Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
