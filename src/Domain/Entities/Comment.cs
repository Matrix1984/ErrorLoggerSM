namespace ErrorLoggerSM.Domain.Entities;
public class Comment : BaseAuditableEntity
{
    public required string Description { get; set; }
}
