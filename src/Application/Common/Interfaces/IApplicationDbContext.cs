using ErrorLoggerSM.Domain.Entities;

namespace ErrorLoggerSM.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Comment> ErrorComments { get; } 

    DbSet<ErrorTag> ErrorTags { get; } 

    DbSet<AlertEmailReceiver> AlertEmailReceivers { get; }

    DbSet<PostErrorActionApiCallConfiguration> PostErrorActionApiCallConfiguration { get; }

    DbSet<SeverityLevel> SeverityLevels { get; }

    DbSet<SysError> SysErrors { get; }
    DbSet<TargetApp> TargetApps { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
