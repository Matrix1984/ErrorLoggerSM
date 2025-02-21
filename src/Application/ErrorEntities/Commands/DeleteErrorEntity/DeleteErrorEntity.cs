using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.ErrorEntities.Commands.DeleteErrorEntity;

public record DeleteErrorEntityCommand(int Id) : IRequest;

public class DeleteErrorEntityCommandHandler : IRequestHandler<DeleteErrorEntityCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteErrorEntityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteErrorEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorEntities
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ErrorEntities.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
