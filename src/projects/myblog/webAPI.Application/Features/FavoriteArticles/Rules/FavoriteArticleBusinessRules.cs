using Application.Features.FavoriteArticles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.FavoriteArticles.Rules;

public class FavoriteArticleBusinessRules : BaseBusinessRules
{
    private readonly IFavoriteArticleRepository _favoriteArticleRepository;

    public FavoriteArticleBusinessRules(IFavoriteArticleRepository favoriteArticleRepository)
    {
        _favoriteArticleRepository = favoriteArticleRepository;
    }

    public Task FavoriteArticleShouldExistWhenSelected(FavoriteArticle? favoriteArticle)
    {
        if (favoriteArticle == null)
            throw new BusinessException(FavoriteArticlesBusinessMessages.FavoriteArticleNotExists);
        return Task.CompletedTask;
    }

    public async Task FavoriteArticleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        FavoriteArticle? favoriteArticle = await _favoriteArticleRepository.GetAsync(
            predicate: fa => fa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FavoriteArticleShouldExistWhenSelected(favoriteArticle);
    }
}