using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IArticleReportRepository : IAsyncRepository<ArticleReport, Guid>, IRepository<ArticleReport, Guid>
{
}