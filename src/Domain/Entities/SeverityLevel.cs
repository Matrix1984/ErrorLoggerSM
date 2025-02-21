namespace ErrorLoggerSM.Domain.Entities;
public class SeverityLevel : BaseEntity
{
    public required string Name { get; set; }

    public required string Level { get; set; }

    public bool IsDeleted { get; set; }
}
