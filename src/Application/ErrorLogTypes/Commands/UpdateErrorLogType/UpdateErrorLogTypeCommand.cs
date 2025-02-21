using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.SeverityLevels.Commands.CreateSeverityLevel;

namespace ErrorLoggerSM.Application.ErrorLogTypes.Commands.UpdateErrorLogType;
public class UpdateErrorLogTypeCommand : IRequest
{
    public required int Id { get; init; }
    public required string Name { get; init; }

    public string? Description { get; init; }

    public CreateSeverityLevelDto SeverityLevel { get; init; } = null!;
}

public class UpdateErrorLogTypeCommandHandler : IRequestHandler<UpdateErrorLogTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateErrorLogTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateErrorLogTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorLogTypes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        entity.Description = request.Description;

        if (entity.SeverityLevel != null)
        {
            entity.SeverityLevel.Name = request.SeverityLevel.Name;

            entity.SeverityLevel.Level = request.SeverityLevel.Level;
        }

        await _context.SaveChangesAsync(cancellationToken);

    }
}
