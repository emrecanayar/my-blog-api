using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ArticleReport : Entity<Guid>
    {
        public ArticleReportType ReportType { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public ArticleReport()
        {
            Article = default!;
        }

        public ArticleReport(Guid id, ArticleReportType reportType, string description, Guid articleId)
        {
            Id = id;
            ReportType = reportType;
            Description = description;
            ArticleId = articleId;
            Article = default!;
        }
    }
}
