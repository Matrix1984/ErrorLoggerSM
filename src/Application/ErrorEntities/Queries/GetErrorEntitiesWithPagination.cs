using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.ErrorEntities.Queries;
public record GetErrorEntitiesWithPaginationQuery : IRequest<PaginatedList<ErrorEntityDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetErrorEntitiesWithPaginationQueryHandler : IRequestHandler<GetErrorEntitiesWithPaginationQuery, PaginatedList<ErrorEntityDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetErrorEntitiesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ErrorEntityDto>> Handle(GetErrorEntitiesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.ErrorEntities
            .Where(x => !x.IsDeleted)
            .OrderByDescending(x => x.Id)
            .ProjectTo<ErrorEntityDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
