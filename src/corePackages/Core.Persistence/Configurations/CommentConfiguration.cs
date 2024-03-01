using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class CommentConfiguration : BaseConfiguration<Comment, Guid>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder);
        builder.Property(c => c.AuthorName).IsRequired(true).HasColumnName("AuthorName").HasMaxLength(LengthContraints.NameMaxLength);
        builder.Property(c => c.AuthorEmail).IsRequired(true).HasColumnName("AuthorEmail").HasMaxLength(LengthContraints.EmailMaxLength);
        builder.Property(c => c.AuhorWebsite).IsRequired(false).HasColumnName("AuhorWebsite").HasMaxLength(250);
        builder.Property(c => c.Content).IsRequired(true).HasColumnName("Content").HasMaxLength(LengthContraints.TextContentLength);
        builder.Property(c => c.DatePosted).IsRequired(true).HasColumnName("DatePosted");
        builder.Property(c => c.SendNewPosts).IsRequired(true).HasColumnName("SendNewPosts");
        builder.Property(c => c.SendNewComments).IsRequired(true).HasColumnName("SendNewComments");
        builder.Property(c => c.RememberMe).IsRequired(true).HasColumnName("RememberMe");
        builder.Property(c => c.ArticleId).IsRequired(true).HasColumnName("ArticleId").HasMaxLength(250);
        builder.Property(c => c.UserId).IsRequired(false).HasColumnName("UserId").HasMaxLength(250);
        builder.HasOne(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId).IsRequired(true);
        builder.HasOne(c => c.User).WithMany(a => a.Comments).HasForeignKey(c => c.UserId).IsRequired(false);
        builder.ToTable(TableNameConstants.COMMENT);

    }
}