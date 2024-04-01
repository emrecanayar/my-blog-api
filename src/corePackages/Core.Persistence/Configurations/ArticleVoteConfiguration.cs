using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ArticleVoteConfiguration : BaseConfiguration<ArticleVote, Guid>
{
    public override void Configure(EntityTypeBuilder<ArticleVote> builder)
    {
        base.Configure(builder);
        builder.Property(av => av.ArticleId).IsRequired(true).HasColumnName("ArticleId").HasMaxLength(250);
        builder.HasOne(av => av.Article).WithMany(a => a.ArticleVotes).HasForeignKey(av => av.ArticleId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(av => av.UserId).IsRequired(true).HasColumnName("UserId").HasMaxLength(250);
        builder.HasOne(av => av.User).WithMany(u => u.ArticleVotes).HasForeignKey(av => av.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.Property(av => av.Vote).IsRequired().HasColumnName("Vote").HasDefaultValue(VoteType.None);
        builder.ToTable(TableNameConstants.ARTICLE_VOTE);

    }
}