using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ReportConfiguration : BaseConfiguration<Report, Guid>
{
    public override void Configure(EntityTypeBuilder<Report> builder)
    {
        base.Configure(builder);
        builder.Property(r => r.Reason).IsRequired(true).HasColumnName("Reason").HasMaxLength(500);
        builder.Property(r => r.UserId).IsRequired(true).HasColumnName("UserId");
        builder.HasOne(r => r.User).WithMany(u => u.Reports).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.Property(r => r.DateReported).IsRequired(true).HasColumnName("DateReported");
        builder.Property(r => r.CommentId).IsRequired(true).HasColumnName("CommentId");
        builder.HasOne(r => r.Comment).WithMany(c => c.Reports).HasForeignKey(r => r.CommentId).OnDelete(DeleteBehavior.NoAction);
        builder.ToTable(TableNameConstants.REPORT);

    }
}