namespace ErrorLoggerSM.Domain.Entities;
public class AlertEmailReceiver : BaseEntity
{
    public required string Name { get; set; }

    public required string Email { get; set; } 
}
