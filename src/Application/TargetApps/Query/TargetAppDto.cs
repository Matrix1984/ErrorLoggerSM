using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetApps.Query;
public class TargetAppDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TargetApp, TargetAppDto>();
        }
    }
}
