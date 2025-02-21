using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorLogTypes.Commands.CreateErrorLogTypeCommand;
public record CreateErrorLogTypeCommand : IRequest<int>
{
    public required string Name { get; init; }

    public string? Description { get; init; }

    public int? SeverityLevelId { get; init; }
}

public class CreateErrorLogTypeCommandHandler : IRequestHandler<CreateErrorLogTypeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateErrorLogTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateErrorLogTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = new ErrorLogType()
        {
            Name = request.Name
        };

        entity.Description = request.Description;

        entity.SeverityLevelId = request.SeverityLevelId;

        _context.ErrorLogTypes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

