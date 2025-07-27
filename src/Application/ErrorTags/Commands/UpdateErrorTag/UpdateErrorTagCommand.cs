using ErrorLoggerSM.Application.Common.Interfaces;

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
    public List<int>? ErrorEntitiesIds { get; init; }
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

        entity.Name = request.Name;

        entity.Description = request.Description;  

        await _context.SaveChangesAsync(cancellationToken);
    }
}
