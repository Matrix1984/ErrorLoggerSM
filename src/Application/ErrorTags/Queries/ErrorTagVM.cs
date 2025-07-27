 
using ErrorLoggerSM.Application.SeverityLevels.Query;
using ErrorLoggerSM.Application.TargetApps.Query; 
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorTags.Queries;
public record ErrorTagVM
{
    public SeverityLevelDto? SeverityLevel { get; init; } 
    public TargetAppDto? TargetApp { get; init; } 
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? AppId { get; init; } 
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ErrorTag, ErrorTagVM>();
        }
    }
}






