using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArticleReports;

public interface IArticleReportsService
{
    Task<ArticleReport?> GetAsync(
        Expression<Func<ArticleReport, bool>> predicate,
        Func<IQueryable<ArticleReport>, IIncludableQueryable<ArticleReport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ArticleReport>?> GetListAsync(
        Expression<Func<ArticleReport, bool>>? predicate = null,
        Func<IQueryable<ArticleReport>, IOrderedQueryable<ArticleReport>>? orderBy = null,
        Func<IQueryable<ArticleReport>, IIncludableQueryable<ArticleReport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ArticleReport> AddAsync(ArticleReport articleReport);
    Task<ArticleReport> UpdateAsync(ArticleReport articleReport);
    Task<ArticleReport> DeleteAsync(ArticleReport articleReport, bool permanent = false);
}
