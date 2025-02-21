using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.SeverityLevels.Commands.DeleteSeverityLevel;

public record DeleteSeverityLevelCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteSeverityLevelCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSeverityLevelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.SeverityLevels
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.SeverityLevels.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
