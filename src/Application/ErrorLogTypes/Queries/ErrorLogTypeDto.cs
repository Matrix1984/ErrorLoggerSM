using ErrorLoggerSM.Application.SeverityLevels.Query;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorLogTypes.Queries;
public class ErrorLogTypeDto
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public SeverityLevelDto? SeverityLevel { get; set; }
}
