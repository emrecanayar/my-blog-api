using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ArticleReportRepository : EfRepositoryBase<ArticleReport, Guid, BaseDbContext>, IArticleReportRepository
{
    public ArticleReportRepository(BaseDbContext context) : base(context)
    {
    }
}