using ErrorLoggerSM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorLoggerSM.Infrastructure.Data.Configurations;
public class ErrorLogTypeConfiguration : IEntityTypeConfiguration<ErrorLogType>
{
    public void Configure(EntityTypeBuilder<ErrorLogType> builder)
    {
        builder.Property(t => t.Name)
          .HasMaxLength(100)
          .IsRequired();
    }
}
