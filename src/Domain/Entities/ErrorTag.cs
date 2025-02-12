namespace ErrorLoggerSM.Domain.Entities;

//Class that will tag user errors by certain criteria. 
public class ErrorTag : BaseEntity
{
    public SeverityLevel? SeverityLevel { get; set; }
    public ErrorLogType? ErrorLogType { get; set; }
    public TargetApp? TargetApp { get; set; }
    public TargetSystem? TargetSystem { get; set; } 
    public required string Name { get; set; }
    public string? Description { get; set; }  
    public string? AppId { get; set; } 
    public List<ErrorEntity>? ErrorEntities { get; set; } // User, manager, operator who caused the action to create the error.
}
