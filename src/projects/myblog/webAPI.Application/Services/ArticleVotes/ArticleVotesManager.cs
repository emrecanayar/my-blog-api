using Application.Features.ArticleVotes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArticleVotes;

public class ArticleVotesManager : IArticleVotesService
{
    private readonly IArticleVoteRepository _articleVoteRepository;
    private readonly ArticleVoteBusinessRules _articleVoteBusinessRules;

    public ArticleVotesManager(IArticleVoteRepository articleVoteRepository, ArticleVoteBusinessRules articleVoteBusinessRules)
    {
        _articleVoteRepository = articleVoteRepository;
        _articleVoteBusinessRules = articleVoteBusinessRules;
    }

    public async Task<ArticleVote?> GetAsync(
        Expression<Func<ArticleVote, bool>> predicate,
        Func<IQueryable<ArticleVote>, IIncludableQueryable<ArticleVote, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ArticleVote? articleVote = await _articleVoteRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return articleVote;
    }

    public async Task<IPaginate<ArticleVote>?> GetListAsync(
        Expression<Func<ArticleVote, bool>>? predicate = null,
        Func<IQueryable<ArticleVote>, IOrderedQueryable<ArticleVote>>? orderBy = null,
        Func<IQueryable<ArticleVote>, IIncludableQueryable<ArticleVote, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ArticleVote> articleVoteList = await _articleVoteRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return articleVoteList;
    }

    public async Task<ArticleVote> AddAsync(ArticleVote articleVote)
    {
        ArticleVote addedArticleVote = await _articleVoteRepository.AddAsync(articleVote);

        return addedArticleVote;
    }

    public async Task<ArticleVote> UpdateAsync(ArticleVote articleVote)
    {
        ArticleVote updatedArticleVote = await _articleVoteRepository.UpdateAsync(articleVote);

        return updatedArticleVote;
    }

    public async Task<ArticleVote> DeleteAsync(ArticleVote articleVote, bool permanent = false)
    {
        ArticleVote deletedArticleVote = await _articleVoteRepository.DeleteAsync(articleVote);

        return deletedArticleVote;
    }
}
