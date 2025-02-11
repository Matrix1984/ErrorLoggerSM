namespace ErrorLoggerSM.Domain.Events;
public class SysErrorCreatedAPIEmail : BaseEvent
{
    public SysErrorCreatedAPIEmail(SysError item)
    {
        Item = item;
    }

    public SysError Item { get; }
}
