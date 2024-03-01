using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class FeatureConfiguration : BaseConfiguration<Feature, Guid>
{
    public override void Configure(EntityTypeBuilder<Feature> builder)
    {
        base.Configure(builder);
        builder.Property(f => f.Title).IsRequired(true).HasColumnName("Title").HasMaxLength(LengthContraints.DescriptionMaxLength);
        builder.ToTable(TableNameConstants.FEATURE);

    }
}