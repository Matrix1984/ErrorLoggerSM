namespace ErrorLoggerSM.Application.ErrorTags.Commands;
public class CreateErrorTagDto
{
    // public CreateSeverityLevelDto? SeverityLevel { get; init; }
    //  public CreateErrorLogTypeDto? ErrorLogType { get; init; }
    //   public CreateTargetAppDto? TargetApp { get; init; }
    //public CreateTargetSystemDto? TargetSystem { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? AppId { get; init; }
    // public List<CreateErrorEntityDto>? ErrorEntities { get; init; } // User, manager, operator who caused the action to create the error.
}
