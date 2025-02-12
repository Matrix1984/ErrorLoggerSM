using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetApps.Query;
public class TargetAppVM
{
    public required string Name { get; set; }
    public ICollection<LogSmEvent>? LogSmEvents { get; set; } = new List<LogSmEvent>();
    public ICollection<SysError>? SysErrors { get; set; } = new List<SysError>();
}
