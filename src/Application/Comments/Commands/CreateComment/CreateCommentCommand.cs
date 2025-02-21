using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.Comments.Commands.CreateComment;
public record CreateCommentCommand : IRequest<int>
{
    public required string Description { get; set; }

    public int SysErrorId { get; set; }
}

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCommentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Comment
        {
            Description = request.Description,
            SysErrorId = request.SysErrorId
        };

        _context.ErrorComments.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
