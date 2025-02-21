using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.TargetSystems.Queries;

public record GetTargetSystemWithPaginationQuery : IRequest<PaginatedList<TargetSystemDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTargetAppWithPaginationQueryHandler : IRequestHandler<GetTargetSystemWithPaginationQuery, PaginatedList<TargetSystemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTargetAppWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TargetSystemDto>> Handle(GetTargetSystemWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.TargetApps
            .Where(x => x.IsDeleted)
            .OrderByDescending(x => x.Id)
            .ProjectTo<TargetSystemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
