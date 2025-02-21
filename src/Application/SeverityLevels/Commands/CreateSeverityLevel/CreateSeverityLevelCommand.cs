using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.SeverityLevels.Commands.CreateSeverityLevel;

public record CreateSeverityLevelCommand : IRequest<int>
{
    public required string Name { get; init; }

    public required string Level { get; init; }
}

public class CreateErrorEntityHandler : IRequestHandler<CreateSeverityLevelCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateErrorEntityHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSeverityLevelCommand request, CancellationToken cancellationToken)
    {
        var entity = new SeverityLevel
        {
            Name = request.Name,
            Level = request.Level
        };

        _context.SeverityLevels.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
