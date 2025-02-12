using ErrorLoggerSM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErrorLoggerSM.Infrastructure.Data.Configurations;
public class SysLogConfiguration : IEntityTypeConfiguration<SysError>
{
    public void Configure(EntityTypeBuilder<SysError> builder)
    {

    }
}
