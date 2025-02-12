using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetSystems.Queries;
public class TargetSystemVM
{
    public required string Name { get; init; }
    public ICollection<LogSmEvent>? LogSmEvents { get; init; } = new List<LogSmEvent>();
    public ICollection<SysError>? SysErrors { get; init; } = new List<SysError>();
}
