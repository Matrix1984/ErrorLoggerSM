using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.Comments.Queries;
public record GetCommentQuery(int Id) : IRequest<CommentDto>;
public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDto>
{
    private readonly IApplicationDbContext _context; 

    public GetCommentQueryHandler(IApplicationDbContext context)
    {
        _context = context; 
    }

    public async Task<CommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorComments
       .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        return new CommentDto()
        {
            Id = entity.Id,
            Description = entity.Description
        };
    }
}
