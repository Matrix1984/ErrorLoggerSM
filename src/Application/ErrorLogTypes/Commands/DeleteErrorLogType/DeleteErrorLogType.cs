using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.ErrorLogTypes.Commands.DeleteErrorLogType;
public record DeleteErrorLogTypeCommand(int Id) : IRequest;

public class DeleteErrorLogTypeCommandHandler : IRequestHandler<DeleteErrorLogTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteErrorLogTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteErrorLogTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorLogTypes
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ErrorLogTypes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
