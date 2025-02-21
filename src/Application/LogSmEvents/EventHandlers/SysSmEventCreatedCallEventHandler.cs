using ErrorLoggerSM.Domain.Events.SysEventEvents;
using Microsoft.Extensions.Logging;

namespace ErrorLoggerSM.Application.LogSmEvents.EventHandlers;
public class SysEventCreatedEventEventHandler : INotificationHandler<SysEventCreatedEvent>
{
    private readonly ILogger<SysEventCreatedEventEventHandler> _logger;

    public SysEventCreatedEventEventHandler(ILogger<SysEventCreatedEventEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SysEventCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ErrorLoggerSM Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
