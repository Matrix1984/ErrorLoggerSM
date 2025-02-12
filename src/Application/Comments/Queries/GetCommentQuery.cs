using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.Comments.Queries;
public record GetCommentQuery(int Id) : IRequest<CommentDto>;


public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCommentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
