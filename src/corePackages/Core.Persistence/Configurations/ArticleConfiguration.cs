using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ArticleConfiguration : BaseConfiguration<Article, Guid>
{
    public override void Configure(EntityTypeBuilder<Article> builder)
    {
        base.Configure(builder);
        builder.Property(a => a.Title).IsRequired(true).HasColumnName("Title").HasMaxLength(LengthContraints.Title);
        builder.Property(a => a.Content).IsRequired(true).HasColumnName("Content").HasColumnType(LengthContraints.MAX);
        builder.Property(a => a.Date).IsRequired(true).HasColumnName("Date");
        builder.Property(a => a.ViewCount).IsRequired(true).HasColumnName("ViewCount");
        builder.Property(a => a.CommentCount).IsRequired(true).HasColumnName("CommentCount");
        builder.Property(a => a.SeoAuthor).IsRequired(true).HasColumnName("SeoAuthor");
        builder.Property(a => a.SeoDescription).IsRequired(true).HasColumnName("SeoDescription").HasMaxLength(150);
        builder.HasOne(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
        builder.HasOne(a => a.User).WithMany(c => c.Articles).HasForeignKey(a => a.UserId);
        builder.ToTable(TableNameConstants.ARTICLE);

    }
}