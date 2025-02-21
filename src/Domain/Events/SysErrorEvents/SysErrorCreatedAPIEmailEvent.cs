namespace ErrorLoggerSM.Domain.Events.SysErrorEvents;
public class SysErrorCreatedAPIEmailEvent : BaseEvent
{
    public SysErrorCreatedAPIEmailEvent(SysError item)
    {
        Item = item;
    }

    public SysError Item { get; }
}
