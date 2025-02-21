namespace ErrorLoggerSM.Domain.Events.SysEventEvents;
public class SysEventCreatedEvent : BaseEvent
{
    public SysEventCreatedEvent(SysEvent item)
    {
        Item = item;
    }

    public SysEvent Item { get; }
}
