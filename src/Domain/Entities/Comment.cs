namespace ErrorLoggerSM.Domain.Entities;
public class Comment : BaseAuditableEntity
{ 
    public int CommentId { get; set; }
    public required string Description { get; set; }
    public long SysErrorId { get; set; }
    public required SysError Errror { get; set; }
}
