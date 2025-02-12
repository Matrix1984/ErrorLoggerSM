using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.SeverityLevels.Query;
public class SeverityLevelDto
{
    public int Id { get; set; }
    public required string Name { get; init; }
    public required string Level { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SeverityLevel, SeverityLevelDto>();
        }
    }
}
