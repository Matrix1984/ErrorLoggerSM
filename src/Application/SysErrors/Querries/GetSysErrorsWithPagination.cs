using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Mappings;
using ErrorLoggerSM.Application.Common.Models;

namespace ErrorLoggerSM.Application.SysErrors.Querries;
public class GetSysErrorsWithPaginationQuery : IRequest<PaginatedList<SysErrorBriefDto>>
{
    public int TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }
    public string? TargetShortDescription { get; set; }
    public string? AppName { get; set; }
    public string? ErrorLogTypeName { get; set; }
    public DateTimeOffset? ErrorGeneratedDateTimeFrom { get; set; }
    public DateTimeOffset? ErrorGeneratedDateTimeTo { get; set; }
    public int TargetAppId { get; set; }
    public int TargetSystemId { get; set; } 
    public string? SortyBy { get; set; }
    public string OrderBy { get; set; } = "ASC";
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10; 
}

public class GetSysErrorsWithPaginationQueryHandler : IRequestHandler<GetSysErrorsWithPaginationQuery, PaginatedList<SysErrorBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSysErrorsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SysErrorBriefDto>> Handle(GetSysErrorsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var sysErrorsQuery = _context.SysErrors;

        if (request.TargetHttpErrorCode > 0)
            sysErrorsQuery.Where(x => x.TargetHttpErrorCode == request.TargetHttpErrorCode);

        if (!String.IsNullOrEmpty(request.TargetAppErrorCode))
            sysErrorsQuery.Where(x => x.TargetAppErrorCode == request.TargetAppErrorCode);

        if (!String.IsNullOrEmpty(request.TargetShortDescription))
            sysErrorsQuery.Where(x => x.TargetShortDescription == request.TargetShortDescription);

        if (!String.IsNullOrEmpty(request.TargetShortDescription))
            sysErrorsQuery.Where(x => x.TargetShortDescription == request.TargetShortDescription);

        if (request.TargetAppId > 0)
            sysErrorsQuery.Where(x => x.TargetAppId == request.TargetAppId); 

        if (request.OrderBy != "ASC")
        {
            if (request.SortyBy == "Id")
                sysErrorsQuery.OrderByDescending(x => x.Id);

            if (request.SortyBy == "TargetHttpErrorCode")
                sysErrorsQuery.OrderByDescending(x => x.TargetHttpErrorCode);

            if (request.SortyBy == "TargetAppErrorCode")
                sysErrorsQuery.OrderByDescending(x => x.TargetAppErrorCode);

            if (request.SortyBy == "TargetShortDescription")
                sysErrorsQuery.OrderByDescending(x => x.TargetShortDescription); 
        }
        else
        {
            if (request.SortyBy == "Id")
                sysErrorsQuery.OrderBy(x => x.Id);

            if (request.SortyBy == "TargetHttpErrorCode")
                sysErrorsQuery.OrderBy(x => x.TargetHttpErrorCode);

            if (request.SortyBy == "TargetAppErrorCode")
                sysErrorsQuery.OrderBy(x => x.TargetAppErrorCode);

            if (request.SortyBy == "TargetShortDescription")
                sysErrorsQuery.OrderBy(x => x.TargetShortDescription);
 
        }

        var query2 = (from n in
                              sysErrorsQuery
                      select new SysErrorBriefDto
                      { 
                          TargetHttpErrorCode = n.TargetHttpErrorCode,
                          TargetAppErrorCode = n.TargetAppErrorCode,
                          TargetShortDescription = n.TargetShortDescription, 
                          TargetAppName = n.TargetApp != null ? n.TargetApp.Name ?? String.Empty : String.Empty, 
                      }); 

        return await query2.PaginatedListAsync(request.PageNumber, request.PageSize);

    }
}


