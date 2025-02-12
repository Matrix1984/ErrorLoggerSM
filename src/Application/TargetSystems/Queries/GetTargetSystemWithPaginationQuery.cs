using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.TargetApps.Query;

namespace ErrorLoggerSM.Application.TargetSystems.Queries;

public record GetTargetSystemWithPaginationQuery : IRequest<PaginatedList<TargetAppDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTargetAppWithPaginationQueryHandler : IRequestHandler<GetTargetSystemWithPaginationQuery, PaginatedList<TargetAppDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTargetAppWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TargetAppDto>> Handle(GetTargetSystemWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.TargetApps
            .OrderBy(x => x.Id)
            .ProjectTo<TargetAppDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
