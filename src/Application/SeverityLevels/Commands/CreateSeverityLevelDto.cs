namespace ErrorLoggerSM.Application.SeverityLevels.Commands;
public class CreateSeverityLevelDto
{
    public required string Name { get; init; }

    public required string Level { get; init; }
}
