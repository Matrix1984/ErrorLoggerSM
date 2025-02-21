namespace ErrorLoggerSM.Domain.Events.SysErrorEvents;
public class SysErrorCreatedEvent : BaseEvent
{
    public SysErrorCreatedEvent(SysError item)
    {
        Item = item;
    }

    public SysError Item { get; }
}
