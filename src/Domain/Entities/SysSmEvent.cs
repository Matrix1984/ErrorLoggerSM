namespace ErrorLoggerSM.Domain.Entities;
public class SysEvent : BaseAuditableEntity
{
    //Code
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }

    //Descriptions
    public string? TargetShortDescription { get; set; } // Exception Summary.
    public string? TargetLongDescription { get; set; } // Exception description.
    public string? TargetTechnicalDescription { get; set; }

    //Error Identifiers  
    public ICollection<ErrorTag>? ErrorTags { get; set; }

    //Log Type

    public int? ErrorLogTypeId { get; set; }
    public ErrorLogType ErrorLogType { get; set; } = null!;

    //Other
    public DateTimeOffset? ErrorGeneratedDateTime { get; set; }
    public ICollection<Comment>? ErrorComments { get; set; }
    public ICollection<PostErrorAction>? PostErrorAction { get; set; }

    //References 
    public int? TargetAppId { get; set; }
    public TargetApp? TargetApp { get; set; }

    public int? TargetSystemId { get; set; }
    public TargetSystem? TargetSystem { get; set; }
}
