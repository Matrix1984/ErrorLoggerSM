using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.Comments.Commands.DeleteComment;
public record DeleteCommentCommand(int Id) : IRequest;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCommentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorComments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.ErrorComments.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
