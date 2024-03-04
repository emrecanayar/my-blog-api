using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HeadArticleFeatures;

public interface IHeadArticleFeaturesService
{
    Task<HeadArticleFeature?> GetAsync(
        Expression<Func<HeadArticleFeature, bool>> predicate,
        Func<IQueryable<HeadArticleFeature>, IIncludableQueryable<HeadArticleFeature, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<HeadArticleFeature>?> GetListAsync(
        Expression<Func<HeadArticleFeature, bool>>? predicate = null,
        Func<IQueryable<HeadArticleFeature>, IOrderedQueryable<HeadArticleFeature>>? orderBy = null,
        Func<IQueryable<HeadArticleFeature>, IIncludableQueryable<HeadArticleFeature, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<HeadArticleFeature> AddAsync(HeadArticleFeature headArticleFeature);
    Task<HeadArticleFeature> UpdateAsync(HeadArticleFeature headArticleFeature);
    Task<HeadArticleFeature> DeleteAsync(HeadArticleFeature headArticleFeature, bool permanent = false);
}
