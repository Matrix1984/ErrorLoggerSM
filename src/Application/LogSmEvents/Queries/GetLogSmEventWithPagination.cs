using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.LogSmEvents.Queries;

public record GetLogSmEventWithPaginationQuery : IRequest<PaginatedList<LogSMEventDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetLogSmEventWithPaginationQueryHandler : IRequestHandler<GetLogSmEventWithPaginationQuery, PaginatedList<LogSMEventDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLogSmEventWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<LogSMEventDto>> Handle(GetLogSmEventWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.LogSmEvents  
               .OrderByDescending(x => x.Id)
               .ProjectTo<LogSMEventDto>(_mapper.ConfigurationProvider)
               .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
