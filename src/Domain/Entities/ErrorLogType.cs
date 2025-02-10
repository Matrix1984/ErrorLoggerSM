namespace ErrorLoggerSM.Domain.Entities;

//The user can define the type of errors that will exist in the system.

public class ErrorLogType : BaseEntity
{
    public required string Name { get; set; }

    public string? Description { get; set; }
}
