namespace ErrorLoggerSM.Domain.Entities;
public class Comment : BaseAuditableEntity
{
    public int SysErrorId { get; set; } 
    public SysError SysError { get; set; } = null!;
    public required string Description { get; set; }
}
