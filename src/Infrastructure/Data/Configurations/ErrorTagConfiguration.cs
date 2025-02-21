using ErrorLoggerSM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorLoggerSM.Infrastructure.Data.Configurations;
public class ErrorTagConfiguration : IEntityTypeConfiguration<ErrorTag>
{
    public void Configure(EntityTypeBuilder<ErrorTag> builder)
    { 
    }
}
