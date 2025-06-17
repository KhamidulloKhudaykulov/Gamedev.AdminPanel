using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mirradev.Admin.Api.Domain.Entities;

namespace Mirradev.Admin.Api.Persistence.Configurations;

public class ClinetConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        
        builder.HasKey(x => x.Id);
        
        builder.HasMany(x => x.Payments)
            .WithOne(x => x.Client)
            .HasForeignKey(x => x.ClientId);
    }
}