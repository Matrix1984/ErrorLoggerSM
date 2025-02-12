using ErrorLoggerSM.Application.ErrorEntities.Queries;
using ErrorLoggerSM.Application.ErrorLogTypes.Queries;
using ErrorLoggerSM.Application.SeverityLevels.Query;
using ErrorLoggerSM.Application.TargetApps.Query;
using ErrorLoggerSM.Application.TargetSystems.Queries;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorTags.Queries;
public record ErrorTagVM
{
    public SeverityLevelDto? SeverityLevel { get; init; }
    public ErrorLogTypeDto? ErrorLogType { get; init; }
    public TargetAppDto? TargetApp { get; init; }
    public TargetSystemDto? TargetSystem { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? AppId { get; init; }
    public IReadOnlyCollection<ErrorEntityDto> ErrorEntities { get; init; } = Array.Empty<ErrorEntityDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ErrorTag, ErrorTagVM>();
        }
    }
}






