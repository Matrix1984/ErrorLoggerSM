namespace ErrorLoggerSM.Domain.Entities;
public class AlertEmailReceiver : BaseEvent
{
    public required string Name { get; set; }

    public required string Email { get; set; }
}
