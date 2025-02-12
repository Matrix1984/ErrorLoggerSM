using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.TargetSystems.Commands.UpdateTargetSystem;
public record UpdateTargetSystemCommand : IRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class UpdateTargetSystemCommandHandler : IRequestHandler<UpdateTargetSystemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTargetSystemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTargetSystemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TargetSystems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

