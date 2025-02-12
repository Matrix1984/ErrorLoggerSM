using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.AlertEmailReceivers.Commands;
public record CreateAlertEmailReceiverCommand : IRequest<int>
{
    public required string Name { get; init; }
    public required string Email { get; init; }
} 

public class CreateAlertEmailReceiverCommandHandler : IRequestHandler<CreateAlertEmailReceiverCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlertEmailReceiverCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlertEmailReceiverCommand request, CancellationToken cancellationToken)
    {
        var entity = new AlertEmailReceiver() { Email = request.Email, Name = request.Name }; 

        _context.AlertEmailReceivers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
