namespace ErrorLoggerSM.Domain.Entities;
public class SeverityLevel : BaseEntity
{
    public required string Name { get; set; } 
    public int Level { get; set; } 
    public bool IsDeleted { get; set; } 
    public ICollection<ErrorTag>? ErrorTags { get; set; }  
}

