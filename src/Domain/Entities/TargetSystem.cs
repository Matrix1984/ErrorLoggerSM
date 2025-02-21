namespace ErrorLoggerSM.Domain.Entities;
public class TargetSystem : BaseEntity
{
    public required string Name { get; set; }

    public ICollection<LogSmEvent>? LogSmEvents { get; set; }

    public ICollection<SysEvent>? SysErrors { get; set; }

    public bool IsDeleted { get; set; }
}
