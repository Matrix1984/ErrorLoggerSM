using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.SeverityLevels.Query;

public record GetSeverityWithPaginationQuery : IRequest<PaginatedList<SeverityLevelDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetSeverityWithPaginationQueryHandler : IRequestHandler<GetSeverityWithPaginationQuery, PaginatedList<SeverityLevelDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSeverityWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SeverityLevelDto>> Handle(GetSeverityWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.SeverityLevels
               .Where(x => !x.IsDeleted)
               .OrderByDescending(x => x.Id)
               .ProjectTo<SeverityLevelDto>(_mapper.ConfigurationProvider)
               .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
