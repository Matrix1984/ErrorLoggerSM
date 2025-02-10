namespace ErrorLoggerSM.Domain.Entities;

//Class that will tag user errors by certain criteria. 
public class ErrorTag : BaseEntity
{
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }

    public string? TargetShortDescription { get; set; } // Exception Summary.
    public string? TargetLongDescription { get; set; } // Exception description.

    public string? TargetTechnicalDescription { get; set; }

    public string? ErrorLocation { get; set; }
    public required string Name { get; set; }

    public string? Description { get; set; }

    public required string SystemName { get; set; }

    public string? AppId { get; set; }

    public List<ErrorEntities>? ErrorEntities { get; set; } // User, manager, operator who caused the action to create the error.
}
