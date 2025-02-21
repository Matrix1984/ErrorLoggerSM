using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.ErrorLogTypes.Queries;

public record GetLogTypeWithPaginationQuery : IRequest<PaginatedList<ErrorLogTypeDto>>
{ 
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetLogTypeWithPaginationQueryHandler : IRequestHandler<GetLogTypeWithPaginationQuery, PaginatedList<ErrorLogTypeDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetLogTypeWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ErrorLogTypeDto>> Handle(GetLogTypeWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ErrorLogTypes
            .Where(x=>!x.IsDeleted)
            .OrderBy(x => x.Id)
            .ProjectTo<ErrorLogTypeDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
