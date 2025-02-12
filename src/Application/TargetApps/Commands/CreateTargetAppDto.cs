using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetApps.Commands;
public class CreateTargetAppDto
{
    public required string Name { get; init; } 
}
