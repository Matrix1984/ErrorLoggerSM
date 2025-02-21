namespace ErrorLoggerSM.Domain.Events.SysEventEvents;
public class SysEventCreatedAPIEmailEvent : BaseEvent
{
    public SysEventCreatedAPIEmailEvent(SysEvent item)
    {
        Item = item;
    }

    public SysEvent Item { get; }
}
