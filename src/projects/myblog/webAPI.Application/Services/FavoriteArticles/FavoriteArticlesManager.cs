using Application.Features.FavoriteArticles.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.FavoriteArticles;

public class FavoriteArticlesManager : IFavoriteArticlesService
{
    private readonly IFavoriteArticleRepository _favoriteArticleRepository;
    private readonly FavoriteArticleBusinessRules _favoriteArticleBusinessRules;

    public FavoriteArticlesManager(IFavoriteArticleRepository favoriteArticleRepository, FavoriteArticleBusinessRules favoriteArticleBusinessRules)
    {
        _favoriteArticleRepository = favoriteArticleRepository;
        _favoriteArticleBusinessRules = favoriteArticleBusinessRules;
    }

    public async Task<FavoriteArticle?> GetAsync(
        Expression<Func<FavoriteArticle, bool>> predicate,
        Func<IQueryable<FavoriteArticle>, IIncludableQueryable<FavoriteArticle, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return favoriteArticle;
    }

    public async Task<IPaginate<FavoriteArticle>?> GetListAsync(
        Expression<Func<FavoriteArticle, bool>>? predicate = null,
        Func<IQueryable<FavoriteArticle>, IOrderedQueryable<FavoriteArticle>>? orderBy = null,
        Func<IQueryable<FavoriteArticle>, IIncludableQueryable<FavoriteArticle, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<FavoriteArticle> favoriteArticleList = await _favoriteArticleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return favoriteArticleList;
    }

    public async Task<FavoriteArticle> AddAsync(FavoriteArticle favoriteArticle)
    {
        FavoriteArticle addedFavoriteArticle = await _favoriteArticleRepository.AddAsync(favoriteArticle);

        return addedFavoriteArticle;
    }

    public async Task<FavoriteArticle> UpdateAsync(FavoriteArticle favoriteArticle)
    {
        FavoriteArticle updatedFavoriteArticle = await _favoriteArticleRepository.UpdateAsync(favoriteArticle);

        return updatedFavoriteArticle;
    }

    public async Task<FavoriteArticle> DeleteAsync(FavoriteArticle favoriteArticle, bool permanent = false)
    {
        FavoriteArticle deletedFavoriteArticle = await _favoriteArticleRepository.DeleteAsync(favoriteArticle);

        return deletedFavoriteArticle;
    }
}
