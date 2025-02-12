using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.TargetApps.Commands.UpdateTargetApp;

public record UpdateTargetAppCommand : IRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTargetAppCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTargetAppCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TargetApps
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

