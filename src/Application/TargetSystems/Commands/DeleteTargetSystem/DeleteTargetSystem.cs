using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.TargetSystems.Commands.DeleteTargetSystem;
public record DeleteTargetSystemCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTargetSystemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTargetSystemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TargetSystems
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
