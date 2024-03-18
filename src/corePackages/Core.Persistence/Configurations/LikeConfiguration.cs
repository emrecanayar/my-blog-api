using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class LikeConfiguration : BaseConfiguration<Like, Guid>
{
    public override void Configure(EntityTypeBuilder<Like> builder)
    {
        base.Configure(builder);
        builder.Property(l => l.UserId).IsRequired(true).HasColumnName("UserId");
        builder.Property(l => l.CommentId).IsRequired(true).HasColumnName("CommentId");
        builder.Property(l => l.IsLiked).IsRequired(true).HasColumnName("IsLiked");
        builder.HasOne(x => x.User).WithMany(x => x.Likes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Comment).WithMany(x => x.Likes).HasForeignKey(x => x.CommentId).OnDelete(DeleteBehavior.NoAction);
        builder.ToTable(TableNameConstants.LIKES);

    }
}