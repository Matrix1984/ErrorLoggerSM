namespace ErrorLoggerSM.Domain.Events.SysEventEvents;
public class SysErrorCreatedAPICallEvent : BaseEvent
{
    public SysErrorCreatedAPICallEvent(SysEvent item)
    {
        Item = item;
    }

    public SysEvent Item { get; }
}
