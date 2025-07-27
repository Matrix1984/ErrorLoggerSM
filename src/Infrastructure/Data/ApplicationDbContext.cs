using System.Reflection;
using ErrorLoggerSM.Application.Common.Interfaces;
using ErrorLoggerSM.Domain.Entities;
using ErrorLoggerSM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErrorLoggerSM.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>(); 

    public DbSet<Comment> ErrorComments => Set<Comment>(); 

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();  

    public DbSet<ErrorTag> ErrorTags => Set<ErrorTag>(); 

    public DbSet<AlertEmailReceiver> AlertEmailReceivers => Set<AlertEmailReceiver>();

    public DbSet<PostErrorActionApiCallConfiguration> PostErrorActionApiCallConfiguration => Set<PostErrorActionApiCallConfiguration>();

    public DbSet<SeverityLevel> SeverityLevels => Set<SeverityLevel>();  

    public DbSet<SysError> SysErrors => Set<SysError>();

    public DbSet<TargetApp> TargetApps => Set<TargetApp>(); 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
