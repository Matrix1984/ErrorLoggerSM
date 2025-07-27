namespace ErrorLoggerSM.Domain.Entities;

//Class that will tag user errors by certain criteria. 
public class ErrorTag : BaseEntity
{    
    //Many-To-Many
    public ICollection<TargetApp>? TargetApps { get; set; }  
    public required string Name { get; set; }
    public string? Description { get; set; }   
    public bool IsDeleted { get; set; }
    public ICollection<SysError>? Errors { get; set; } // User, manager, operator who caused the action to create the error.
}
