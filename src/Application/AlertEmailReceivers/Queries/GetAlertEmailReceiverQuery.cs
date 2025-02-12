using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Application.Common.Security;

namespace ErrorLoggerSM.Application.AlertEmailReceivers.Queries;

[Authorize]
public record GetAlertEmailReceiverQuery : IRequest<IReadOnlyCollection<AlertEmailReceiverDto>>;

public class GetAlertEmailReceiverQueryHandler : IRequestHandler<GetAlertEmailReceiverQuery, IReadOnlyCollection<AlertEmailReceiverDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAlertEmailReceiverQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<AlertEmailReceiverDto>> Handle(GetAlertEmailReceiverQuery request, CancellationToken cancellationToken)
    {
        return await _context.AlertEmailReceivers
                .AsNoTracking()
                .ProjectTo<AlertEmailReceiverDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
    }
}
