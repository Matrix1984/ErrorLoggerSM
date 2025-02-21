using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models; 

namespace ErrorLoggerSM.Application.TargetApps.Query;
public record GetTargetAppWithPaginationQuery : IRequest<PaginatedList<TargetAppDto>>
{ 
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTargetAppWithPaginationQueryHandler : IRequestHandler<GetTargetAppWithPaginationQuery, PaginatedList<TargetAppDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTargetAppWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TargetAppDto>> Handle(GetTargetAppWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.TargetApps
            .Where(x=>!x.IsDeleted)
            .OrderByDescending(x => x.Id)
            .ProjectTo<TargetAppDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
