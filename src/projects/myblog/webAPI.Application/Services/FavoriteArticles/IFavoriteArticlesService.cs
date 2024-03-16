using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FavoriteArticles;

public interface IFavoriteArticlesService
{
    Task<FavoriteArticle?> GetAsync(
        Expression<Func<FavoriteArticle, bool>> predicate,
        Func<IQueryable<FavoriteArticle>, IIncludableQueryable<FavoriteArticle, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<FavoriteArticle>?> GetListAsync(
        Expression<Func<FavoriteArticle, bool>>? predicate = null,
        Func<IQueryable<FavoriteArticle>, IOrderedQueryable<FavoriteArticle>>? orderBy = null,
        Func<IQueryable<FavoriteArticle>, IIncludableQueryable<FavoriteArticle, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<FavoriteArticle> AddAsync(FavoriteArticle favoriteArticle);
    Task<FavoriteArticle> UpdateAsync(FavoriteArticle favoriteArticle);
    Task<FavoriteArticle> DeleteAsync(FavoriteArticle favoriteArticle, bool permanent = false);
}
