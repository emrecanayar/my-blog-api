using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class RatingConfiguration : BaseConfiguration<Rating, Guid>
{
    public override void Configure(EntityTypeBuilder<Rating> builder)
    {
        base.Configure(builder);
        builder.Property(r => r.Score).IsRequired(true).HasColumnName("Score");
        builder.Property(r => r.UserId).IsRequired(false).HasColumnName("UserId");
        builder.Property(r => r.ArticleId).IsRequired(true).HasColumnName("ArticleId");
        builder.HasOne(r => r.User).WithMany(x => x.Ratings).HasForeignKey(r => r.UserId);
        builder.HasOne(r => r.Article).WithMany(x => x.Ratings).HasForeignKey(r => r.ArticleId);
        builder.ToTable(TableNameConstants.RATING);

    }
}