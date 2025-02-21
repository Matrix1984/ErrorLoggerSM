namespace ErrorLoggerSM.Application.SysErrors.Querries;
public class SysErrorBriefDto
{
    public int Id { get; set; }
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }
    public string? TargetShortDescription { get; set; }
    public string? ErrorLogTypeName { get; set; }
    public DateTimeOffset? ErrorGeneratedDateTime { get; set; }
    public string TargetAppName { get; set; } = null!;
    public string TargetSystemName { get; set; } = null!;
}
