using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mirradev.Admin.Api.Persistence.Configurations;

public class AdminConfigurations : IEntityTypeConfiguration<Domain.Entities.Admin>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Admin> builder)
    {
        builder.ToTable("Admins");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).IsRequired(true);
        builder.Property(x => x.Password).IsRequired(true);
    }
}