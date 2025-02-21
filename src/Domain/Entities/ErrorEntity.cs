namespace ErrorLoggerSM.Domain.Entities;
public class ErrorEntity : BaseEntity
{
    public required string Name { get; set; }

    public bool IsDeleted { get; set; }
}
