using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using Core.Persistence.Configurations.Base;
using Core.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.EntityConfigurations;

public class ArticleReportConfiguration : BaseConfiguration<ArticleReport, Guid>
{
    public override void Configure(EntityTypeBuilder<ArticleReport> builder)
    {
        base.Configure(builder);

        builder.Property(ar => ar.Description).IsRequired(false).HasColumnName("Description").HasMaxLength(500);
        builder.Property(ar => ar.ArticleId).IsRequired(true).HasColumnName("ArticleId");
        builder.Property(ar => ar.ReportType).IsRequired(true).HasColumnName("ReportType").HasDefaultValue(ArticleReportType.None);
        builder.HasOne(ar => ar.Article).WithMany(a => a.ArticleReports).HasForeignKey(ar => ar.ArticleId).OnDelete(DeleteBehavior.NoAction);
        builder.ToTable(TableNameConstants.ARTICLE_REPORT);

    }
}