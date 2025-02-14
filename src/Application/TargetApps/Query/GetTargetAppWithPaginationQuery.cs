﻿using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;
using ErrorLoggerSM.Application.TargetSystems.Queries;

namespace ErrorLoggerSM.Application.TargetApps.Query;
public record GetTargetSystemWithPaginationQuery : IRequest<PaginatedList<TargetSystemDto>>
{
    public int ListId { get; init; }
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
            .OrderBy(x => x.Id)
            .ProjectTo<TargetSystemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
