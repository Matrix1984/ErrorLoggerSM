using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorTags.Commands.UpdateErrorTag;

public class UpdateErrorTagCommand : IRequest
{
    public int Id { get; init; }
    public int? SeverityLevelId { get; init; }
    public int? ErrorLogTypeId { get; init; }
    public int? TargetAppId { get; init; }
    public int? TargetSystemId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public string? AppId { get; init; }
    public List<string>? ErrorEntities { get; init; }
}

public class UpdateErrorLogTypeCommandHandler : IRequestHandler<UpdateErrorTagCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateErrorLogTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateErrorTagCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorTags
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.SeverityLevelId = request.SeverityLevelId;

        entity.ErrorLogTypeId = request.ErrorLogTypeId;

        entity.TargetAppId = request.TargetAppId;

        entity.TargetSystemId = request.TargetSystemId;

        entity.Name = request.Name;

        entity.Description = request.Description;

        entity.AppId = request.AppId;

        entity.ErrorEntities = new List<ErrorEntity>();

        if (request.ErrorEntities != null)
            foreach (var item in request.ErrorEntities)
            {
                entity.ErrorEntities.Add(new ErrorEntity() { Name = item });
            }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
