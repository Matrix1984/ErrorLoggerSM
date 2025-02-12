//using ErrorLoggerSM.Application.Comments.Commands.CreateComment;
//using ErrorLoggerSM.Application.Common.Interfaces;
//using ErrorLoggerSM.Application.ErrorLogType.Commands;
//using ErrorLoggerSM.Application.ErrorTag.Commands;
//using ErrorLoggerSM.Application.TargetApps.Commands;
//using ErrorLoggerSM.Application.TargetSystems.Commands;
//using ErrorLoggerSM.Domain.Entities;
//using ErrorLoggerSM.Domain.Enums;
//using ErrorLoggerSM.Domain.Events;

//namespace ErrorLoggerSM.Application.SysErrors.Commands.CreateSysError;

//public record CreateSysErrorCommand : IRequest<int>
//{
//    public int? TargetHttpErrorCode { get; init; }
//    public string? TargetAppErrorCode { get; init; }
//    public string? TargetShortDescription { get; init; }
//    public string? TargetLongDescription { get; init; }
//    public string? TargetTechnicalDescription { get; init; }
//    public string? AppId { get; init; }
//  //  public IReadOnlyCollection<CreateErrorTagDto>? ErrorTags { get; init; }
// //   public CreateErrorLogTypeDto? ErrorLogType { get; init; }
//    public DateTimeOffset? ErrorGeneratedDateTime { get; init; }
//    public IReadOnlyCollection<CreateCommentDto>? ErrorComments { get; init; } 
//    public IReadOnlyCollection<PostErrorAction>? PostErrorAction { get; init; } 
//    public CreateTargetAppDto? TargetApp { get; init; } 
//    public CreateTargetSystemDto? TargetSystem { get; init; }  
//}

//public class CreateTodoItemCommandHandler : IRequestHandler<CreateSysErrorCommand, int>
//{
//    private readonly IApplicationDbContext _context;

//    public CreateTodoItemCommandHandler(IApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<int> Handle(CreateSysErrorCommand request, CancellationToken cancellationToken)
//    {
//        var entity = new TodoItem
//        {
//            ListId = request.ListId,
//            Title = request.Title,
//            Done = false
//        };
         
//        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

//        _context.TodoItems.Add(entity);

//        await _context.SaveChangesAsync(cancellationToken);

//        return entity.Id;
//    }
//}
