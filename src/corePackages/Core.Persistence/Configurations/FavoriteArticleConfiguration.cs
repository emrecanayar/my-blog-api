using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class FavoriteArticleConfiguration : BaseConfiguration<FavoriteArticle, Guid>
{
    public override void Configure(EntityTypeBuilder<FavoriteArticle> builder)
    {
        base.Configure(builder);
        builder.Property(fa => fa.UserId).IsRequired(true).HasColumnName("UserId");
        builder.Property(fa => fa.ArticleId).IsRequired(true).HasColumnName("ArticleId");
        builder.HasOne(x => x.User).WithMany(x => x.FavoriteArticles).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Article).WithMany(x => x.FavoriteArticles).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.NoAction);
        builder.ToTable(TableNameConstants.FAVORITE_ARTICLE);

    }
}