using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetApps.Commands.CreateTargetApp;
public record CreateTargetAppCommand : IRequest<int>
{
    public required string Name { get; set; }
}

public class CreateTargetAppCommandHandler : IRequestHandler<CreateTargetAppCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTargetAppCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTargetAppCommand request, CancellationToken cancellationToken)
    {
        var entity = new TargetApp
        {
            Name = request.Name
        };

        _context.TargetApps.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
