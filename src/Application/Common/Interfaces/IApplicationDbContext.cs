using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
     DbSet<Comment> ErrorComments { get; } 

     DbSet<ErrorEntity> ErrorEntities { get; }

     DbSet<ErrorLogType> ErrorLogTypes { get; }

     DbSet<ErrorTag> ErrorTags { get; }

     DbSet<LogSmEvent> LogSmEvents { get; }

     DbSet<AlertEmailReceiver> AlertEmailReceivers { get; }

     DbSet<PostErrorActionApiCallConfiguration> PostErrorActionApiCallConfiguration { get; }

     DbSet<SeverityLevel> SeverityLevels { get; }

     DbSet<SysError> SysErrors { get; }

    DbSet<SysEvent> SysEvents { get; }
    DbSet<TargetApp> TargetApps { get; }

     DbSet<TargetSystem> TargetSystems { get; }
     
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
