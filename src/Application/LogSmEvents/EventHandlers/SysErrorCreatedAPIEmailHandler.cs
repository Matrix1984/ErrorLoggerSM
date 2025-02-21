using ErrorLoggerSM.Domain.Events.SysEventEvents;
using Microsoft.Extensions.Logging;

namespace ErrorLoggerSM.Application.LogSmEvents.EventHandlers;
public class SysEventCreatedAPIEmailHandler : INotificationHandler<SysEventCreatedAPIEmailEvent>
{
    private readonly ILogger<SysEventCreatedAPIEmailHandler> _logger;

    public SysEventCreatedAPIEmailHandler(ILogger<SysEventCreatedAPIEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SysEventCreatedAPIEmailEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ErrorLoggerSM Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
