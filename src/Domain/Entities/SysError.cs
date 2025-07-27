namespace ErrorLoggerSM.Domain.Entities;
public class SysError : BaseAuditableEntity
{
    public new long Id { get; set; }

    //Code
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }

    //Descriptions
    public string? TargetShortDescription { get; set; } // Exception Summary.
    public string? TargetLongDescription { get; set; } // Exception description.
    public string? TargetTechnicalDescription { get; set; }

    //Error Identifiers  //Many-To-Many
    public ICollection<ErrorTag>? ErrorTags { get; set; } 

    public int? SeverityLevelId { get; set; }
    public SeverityLevel? SeverityLevel { get; set; }

    //Other
    public DateTimeOffset? GeneratedDateTime { get; set; }
    public ICollection<Comment>? ErrorComments { get; set; }
    public ICollection<PostErrorAction>? PostErrorAction { get; set; } 

    //References 
    public int? TargetAppId { get; set; }
    public TargetApp? TargetApp { get; set; } 
}
