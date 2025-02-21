using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.Comments.Queries;
public record GetCommentQueryWithPaginationQuery : IRequest<PaginatedList<CommentDto>>
{
    public int SysErrorId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCommentQueryWithPaginationQueryHandler : IRequestHandler<GetCommentQueryWithPaginationQuery, PaginatedList<CommentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCommentQueryWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CommentDto>> Handle(GetCommentQueryWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ErrorComments
            .Where(x => x.SysErrorId == request.SysErrorId)
            .OrderByDescending(x => x.Id)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
