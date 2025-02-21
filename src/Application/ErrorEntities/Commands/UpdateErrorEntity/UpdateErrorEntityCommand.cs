using ErrorLoggerSM.Application.Common.Interfaces;

namespace ErrorLoggerSM.Application.ErrorEntities.Commands.UpdateErrorEntity;

public record UpdateErrorEntityCommand : IRequest
{
    public int Id { get; init; }

    public required string Name { get; init; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateErrorEntityCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateErrorEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ErrorEntities
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
