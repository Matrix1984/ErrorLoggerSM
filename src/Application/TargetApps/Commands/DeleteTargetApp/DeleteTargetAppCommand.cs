using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.TargetApps.Commands.DeleteTargetApp;

public record DeleteTargetAppCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTargetAppCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTargetAppCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TargetApps
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TargetApps.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
