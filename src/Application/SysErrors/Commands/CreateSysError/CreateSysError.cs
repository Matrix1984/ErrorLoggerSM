﻿using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;
using ErrorLoggerSM.Domain.Events.SysErrorEvents;

namespace ErrorLoggerSM.Application.SysErrors.Commands.CreateSysError;

public record CreateSysErrorCommand : IRequest<int>
{
    public int? TargetHttpErrorCode { get; set; }
    public string? TargetAppErrorCode { get; set; }
    public string? TargetShortDescription { get; set; }
    public string? TargetLongDescription { get; set; }
    public string? TargetTechnicalDescription { get; set; }
    public int? ErrorLogTypeId { get; set; }
    public ICollection<int>? ErrorTagIds { get; set; }
    public DateTimeOffset? ErrorGeneratedDateTime { get; set; }
    public ICollection<int>? PostErrorActions { get; set; }
    public int? TargetAppId { get; set; }
    public int? TargetSystemId { get; set; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateSysErrorCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSysErrorCommand request, CancellationToken cancellationToken)
    {
        var entity = new SysError();

        entity.TargetHttpErrorCode = request.TargetHttpErrorCode;

        entity.TargetAppErrorCode = request.TargetAppErrorCode;

        entity.TargetShortDescription = request.TargetShortDescription;

        entity.TargetLongDescription = request.TargetLongDescription;

        entity.TargetTechnicalDescription = request.TargetTechnicalDescription;

        entity.ErrorLogTypeId = request.ErrorLogTypeId;

        entity.ErrorGeneratedDateTime = request.ErrorGeneratedDateTime;

        entity.TargetAppId = request.TargetAppId;

        entity.TargetSystemId = request.TargetSystemId;

        if (request.PostErrorActions != null)
            foreach (var item in request.PostErrorActions)
            {
                if (item == 0)
                    entity.AddDomainEvent(new SysErrorCreatedAPIEmailEvent(entity));

                if (item == 1)
                    entity.AddDomainEvent(new SysErrorCreatedEvent(entity));

                if (item == 2)
                    entity.AddDomainEvent(new SysErrorCreatedAPICallEvent(entity));
            }

        if (request.ErrorTagIds != null)
            entity.ErrorTags = await (from c in _context.ErrorTags
                                      join d in request.ErrorTagIds on c.Id equals d
                                      select c).ToListAsync(cancellationToken);

        _context.SysErrors.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
