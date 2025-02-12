using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.ErrorEntities.Commands.CreateErrorEntity;
public record CreateErrorEntityCommand : IRequest<int>
{
    public required string Name { get; init; }
}

public class CreateErrorEntityHandler : IRequestHandler<CreateErrorEntityCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateErrorEntityHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateErrorEntityCommand request, CancellationToken cancellationToken)
    {
        var entity = new ErrorEntity
        {
            Name = request.Name 
        };

        _context.ErrorEntities.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
