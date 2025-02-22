﻿namespace ErrorLoggerSM.Domain.Entities;

//Class that will tag user errors by certain criteria. 
public class ErrorTag : BaseEntity
{
    public int? SeverityLevelId { get; set; }
    public SeverityLevel? SeverityLevel { get; set; } 
    public int? ErrorLogTypeId { get; set; }
    public ErrorLogType? ErrorLogType { get; set; } 
    public int? TargetAppId { get; set; }
    public TargetApp? TargetApp { get; set; } 
    public int? TargetSystemId { get; set; }
    public TargetSystem? TargetSystem { get; set; } 
    public required string Name { get; set; }
    public string? Description { get; set; }   
    public bool IsDeleted { get; set; }
    public List<ErrorEntity>? ErrorEntities { get; set; } // User, manager, operator who caused the action to create the error.
}
