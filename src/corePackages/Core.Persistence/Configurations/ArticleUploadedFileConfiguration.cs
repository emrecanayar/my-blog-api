using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ArticleUploadedFileConfiguration : BaseConfiguration<ArticleUploadedFile, Guid>
{
    public override void Configure(EntityTypeBuilder<ArticleUploadedFile> builder)
    {
        base.Configure(builder);
        builder.Property(auf => auf.ArticleId).IsRequired(true).HasColumnName("ArticleId");
        builder.Property(auf => auf.UploadedFileId).IsRequired(true).HasColumnName("UploadedFileId");
        builder.Property(auf => auf.OldPath).IsRequired(true).HasColumnName("OldPath").HasMaxLength(250);
        builder.Property(auf => auf.NewPath).IsRequired(true).HasColumnName("NewPath").HasMaxLength(250);
        builder.HasOne(auf => auf.Article).WithMany(c => c.ArticleUploadedFiles).HasForeignKey(cuf => cuf.ArticleId);
        builder.HasOne(auf => auf.UploadedFile).WithMany(c => c.ArticleUploadedFiles).HasForeignKey(auf => auf.UploadedFileId);
        builder.ToTable(TableNameConstants.ARTICLE_UPLOADED_FILE);

    }
}


