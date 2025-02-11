namespace ErrorLoggerSM.Domain.Entities;
public class SysError : BaseEntity
{
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }
    public string? TargetShortDescription { get; set; } // Exception Summary.
    public string? TargetLongDescription { get; set; } // Exception description.
    public string? TargetTechnicalDescription { get; set; }
    public string? ErrorLocation { get; set; }
    public SeverityLevel? SeverityLevel { get; set; }
    public ErrorLogType? ErrorLogType { get; set; }
    public TargetApp? TargetApp { get; set; }
    public TargetSystem? TargetSystem { get; set; }
    public List<PostErrorAction>? ErrorActions { get; set; }
    public ErrorTag? ErrorTag { get; set; }
}
