using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorTags.Commands.CreateErrorTag;

public record CreateErrorTagCommand : IRequest<int>
{
    public int? SeverityLevelId { get; init; }
    public int? ErrorLogTypeId { get; init; }
    public int? TargetAppId { get; init; }
    public int? TargetSystemId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? AppId { get; init; }
    public List<string>? ErrorEntities { get; init; }
}

public class CreateErrorEntityHandler : IRequestHandler<CreateErrorTagCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateErrorEntityHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateErrorTagCommand request, CancellationToken cancellationToken)
    {
        var entity = new ErrorTag
        {
            Name = request.Name
        };

        entity.SeverityLevelId = request.SeverityLevelId;

        entity.ErrorLogTypeId = request.ErrorLogTypeId;

        entity.TargetAppId = request.TargetAppId;

        entity.TargetSystemId = request.TargetSystemId;

        entity.Name = request.Name;

        entity.Description = request.Description; 

        entity.ErrorEntities = new List<ErrorEntity>();

        if (request.ErrorEntities != null)
            foreach (var item in request.ErrorEntities)
            {
                entity.ErrorEntities.Add(new ErrorEntity() { Name = item });
            }

        _context.ErrorTags.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
