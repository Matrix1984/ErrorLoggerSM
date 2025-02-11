namespace ErrorLoggerSM.Domain.Entities;
public class SmtpConfigurations : BaseEvent
{
    public required string EmailHost { get; set; }
}
