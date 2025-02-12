namespace ErrorLoggerSM.Application.SeverityLevels.Query;
public class SeverityLevelDto
{
    public int Id { get; set; }
    public required string Name { get; init; }
    public required string Level { get; init; }
}
