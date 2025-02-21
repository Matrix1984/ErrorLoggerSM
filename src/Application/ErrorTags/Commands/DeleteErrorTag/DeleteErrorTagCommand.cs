using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.ErrorTags.Commands.DeleteErrorTag;

public record DeleteErrorTagCommand(int Id) : IRequest;

public class DeleteErrorTagCommandHandler : IRequestHandler<DeleteErrorTagCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteErrorTagCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteErrorTagCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorTags
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);
    }

}
