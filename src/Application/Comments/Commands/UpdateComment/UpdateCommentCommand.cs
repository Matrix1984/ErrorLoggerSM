using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.Comments.Commands.UpdateComment;

public record UpdateCommentCommand : IRequest
{
    public int Id { get; set; }
    public required string Description { get; set; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateCommentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorComments
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

