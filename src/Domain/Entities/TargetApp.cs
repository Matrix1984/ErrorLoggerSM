namespace ErrorLoggerSM.Domain.Entities;
public class TargetApp : BaseEntity
{
    public required string Name { get; set; } 

    public bool IsDeleted { get; set; }

    public ICollection<SysError>? SysErrors { get; set; }
}
