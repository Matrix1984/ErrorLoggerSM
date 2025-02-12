using ErrorLoggerSM.Domain.Events;
using Microsoft.Extensions.Logging;

namespace ErrorLoggerSM.Application.SysErrors.EventHandlers;
public class SysErrorCreatedAPIEmailHandler : INotificationHandler<SysErrorCreatedAPIEmailEvent>
{
    private readonly ILogger<SysErrorCreatedAPIEmailHandler> _logger;

    public SysErrorCreatedAPIEmailHandler(ILogger<SysErrorCreatedAPIEmailHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SysErrorCreatedAPIEmailEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("ErrorLoggerSM Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
