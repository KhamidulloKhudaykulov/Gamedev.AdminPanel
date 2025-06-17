using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mirradev.Admin.Api.Domain.Entities;

namespace Mirradev.Admin.Api.Persistence.Configurations;

public class TokenRateConfigurations : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("TokenRates");
        
        builder.HasKey(x => x.Id);
    }
}