using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class FooterConfiguration : BaseConfiguration<Footer, Guid>
{
    public override void Configure(EntityTypeBuilder<Footer> builder)
    {
        base.Configure(builder);
        builder.Property(f => f.Title).IsRequired(true).HasColumnName("Title").HasMaxLength(250);
        builder.Property(f => f.Description).IsRequired(true).HasColumnName("Description").HasMaxLength(750);
        builder.ToTable(TableNameConstants.FOOTER);

    }
}