using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class HeadArticleFeatureUploadedFileConfiguration : BaseConfiguration<HeadArticleFeatureUploadedFile, Guid>
{
    public override void Configure(EntityTypeBuilder<HeadArticleFeatureUploadedFile> builder)
    {
        base.Configure(builder);
        builder.Property(hafuf => hafuf.OldPath).IsRequired(true).HasColumnName("OldPath").HasMaxLength(250);
        builder.Property(hafuf => hafuf.NewPath).IsRequired(true).HasColumnName("NewPath").HasMaxLength(250);
        builder.HasOne(hafuf => hafuf.HeadArticleFeature).WithMany(haf => haf.HeadArticleFeatureUploadedFiles).HasForeignKey(hafuf => hafuf.HeadArticleFeatureId);
        builder.HasOne(hafuf => hafuf.UploadedFile).WithMany(uf => uf.HeadArticleFeatureUploadedFiles).HasForeignKey(hafuf => hafuf.UploadedFileId);
        builder.ToTable(TableNameConstants.HEAD_ARTICLE_FEATURE_UPLOADED_FILE);

    }
}