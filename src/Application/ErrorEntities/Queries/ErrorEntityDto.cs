using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorEntities.Queries;
public class ErrorEntityDto
{
    public int Id { get; init; }
    public required string Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ErrorEntity, ErrorEntityDto>();
        }
    }
}
