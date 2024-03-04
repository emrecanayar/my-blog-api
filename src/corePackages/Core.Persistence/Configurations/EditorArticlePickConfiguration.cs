using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class EditorArticlePickConfiguration : BaseConfiguration<EditorArticlePick, Guid>
{
    public override void Configure(EntityTypeBuilder<EditorArticlePick> builder)
    {
        base.Configure(builder);
        builder.HasOne(eap => eap.User).WithMany(x => x.EditorArticlePicks).HasForeignKey(eap => eap.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(eap => eap.Article).WithMany(x => x.EditorArticlePicks).HasForeignKey(eap => eap.ArticleId).OnDelete(DeleteBehavior.Restrict);
        builder.ToTable(TableNameConstants.EDITOR_ARTICLE_PICK);

    }
}