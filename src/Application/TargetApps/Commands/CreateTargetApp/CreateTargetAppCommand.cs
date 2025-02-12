using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.TargetApps.Commands.CreateTargetApp;
public record CreateTargetSystemCommand : IRequest<int>
{
    public required string Name { get; set; }
}

public class CreateTargetSystemCommandHandler : IRequestHandler<CreateTargetSystemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTargetSystemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTargetSystemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TargetSystem
        {
            Name = request.Name
        };

        _context.TargetSystems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
