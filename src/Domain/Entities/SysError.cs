namespace ErrorLoggerSM.Domain.Entities;
public class SysError : BaseAuditableEntity
{
    //Code
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }

    //Descriptions
    public string? TargetShortDescription { get; set; } // Exception Summary.
    public string? TargetLongDescription { get; set; } // Exception description.
    public string? TargetTechnicalDescription { get; set; }

    //Error Identifiers 
    public string? AppId { get; set; }
    public ICollection<ErrorTag>? ErrorTags { get; set; }

    //Log Type
    public ErrorLogType ErrorLogType { get; set; } = null!;

    //Other
    public DateTimeOffset? ErrorGeneratedDateTime { get; set; }
    public ICollection<Comment>? ErrorComments { get; set; }
    public ICollection<PostErrorAction>? PostErrorAction { get; set; }

    public ICollection<Comment>? Comments { get; set; }

    //References 
    public TargetApp? TargetApp { get; set; }
    public TargetSystem? TargetSystem { get; set; }
}
