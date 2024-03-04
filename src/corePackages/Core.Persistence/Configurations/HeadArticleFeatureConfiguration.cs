using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class HeadArticleFeatureConfiguration : BaseConfiguration<HeadArticleFeature, Guid>
{
    public override void Configure(EntityTypeBuilder<HeadArticleFeature> builder)
    {
        base.Configure(builder);
        builder.Property(haf => haf.Title).IsRequired(true).HasColumnName("Title").HasMaxLength(LengthContraints.Title);
        builder.Property(haf => haf.Content).IsRequired(true).HasColumnName("Content").HasColumnType(LengthContraints.MAX);
        builder.HasOne(haf => haf.Category).WithMany(c => c.HeadArticleFeatures).HasForeignKey(haf => haf.CategoryId).IsRequired();
        builder.ToTable(TableNameConstants.HEAD_ARTICLE_FEATURE);

    }
}