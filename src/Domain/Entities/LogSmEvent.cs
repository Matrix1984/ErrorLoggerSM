namespace ErrorLoggerSM.Domain.Entities;
public class LogSmEvent : BaseAuditableEntity
{
    public required string Name { get; set; }
     
    public ICollection<Comment>? Comments { get; set; }
}
