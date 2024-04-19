using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class NotificationConfiguration : BaseConfiguration<Notification, Guid>
{
    public override void Configure(EntityTypeBuilder<Notification> builder)
    {
        base.Configure(builder);
        builder.Property(n => n.UserId).IsRequired(false).HasColumnName("UserId");
        builder.Property(n => n.ArticleId).IsRequired(false).HasColumnName("ArticleId");
        builder.Property(n => n.CommentId).IsRequired(false).HasColumnName("CommentId");
        builder.Property(n => n.RatingId).IsRequired(false).HasColumnName("RatingId");
        builder.Property(n => n.LikeId).IsRequired(false).HasColumnName("LikeId");
        builder.Property(n => n.Type).IsRequired(true).HasColumnName("Type").HasMaxLength(250);
        builder.Property(n => n.Content).IsRequired(true).HasColumnName("Content").HasMaxLength(250);
        builder.Property(n => n.IsRead).IsRequired(true).HasColumnName("IsRead").HasMaxLength(250);
        builder.HasOne(x => x.User).WithMany(x => x.Notifications).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Article).WithMany(x => x.Notifications).HasForeignKey(x => x.ArticleId);
        builder.HasOne(x => x.Comment).WithMany(x => x.Notifications).HasForeignKey(x => x.CommentId);
        builder.HasOne(x => x.Rating).WithMany(x => x.Notifications).HasForeignKey(x => x.RatingId);
        builder.HasOne(x => x.Like).WithMany(x => x.Notifications).HasForeignKey(x => x.LikeId);
        builder.ToTable(TableNameConstants.NOTIFICATION);
    }
}