using ErrorLoggerSM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorLoggerSM.Infrastructure.Data.Configurations;
public class LogSmEventSmConfiguration : IEntityTypeConfiguration<LogSmEvent>
{
    public void Configure(EntityTypeBuilder<LogSmEvent> builder)
    {
        builder.Property(t => t.Name)
        .HasMaxLength(100);
    }
}
