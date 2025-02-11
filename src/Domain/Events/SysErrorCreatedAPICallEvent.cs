namespace ErrorLoggerSM.Domain.Events;
public class SysErrorCreatedAPICallEvent : BaseEvent
{
    public SysErrorCreatedAPICallEvent(SysError item)
    {
        Item = item;
    }

    public SysError Item { get; }
}
