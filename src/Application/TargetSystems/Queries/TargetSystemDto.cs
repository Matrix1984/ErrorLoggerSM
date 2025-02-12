using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetSystems.Queries;
public class TargetSystemDto
{
    public int Id { get; init; }
    public required string Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TargetSystem, TargetSystemDto>();
        }
    }
}
