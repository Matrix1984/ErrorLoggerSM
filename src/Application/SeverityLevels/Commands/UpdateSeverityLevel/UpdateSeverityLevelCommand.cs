using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.SeverityLevels.Commands.UpdateSeverityLevel; 

public record UpdateSeverityLevelCommand : IRequest
{
    public int Id { get; init; }
    public required string Name { get; init; }

    public required string Level { get; init; }
}

public class UpdateSeverityLevelCommandHandler : IRequestHandler<UpdateSeverityLevelCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSeverityLevelCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSeverityLevelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.SeverityLevels
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        if (!String.IsNullOrEmpty(request.Name))
            entity.Name = request.Name;

        if (!String.IsNullOrEmpty(request.Level))
            entity.Level = request.Level;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
