using Application.Features.ArticleVotes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.ArticleVotes.Rules;

public class ArticleVoteBusinessRules : BaseBusinessRules
{
    private readonly IArticleVoteRepository _articleVoteRepository;

    public ArticleVoteBusinessRules(IArticleVoteRepository articleVoteRepository)
    {
        _articleVoteRepository = articleVoteRepository;
    }

    public Task ArticleVoteShouldExistWhenSelected(ArticleVote? articleVote)
    {
        if (articleVote == null)
            throw new BusinessException(ArticleVotesBusinessMessages.ArticleVoteNotExists);
        return Task.CompletedTask;
    }

    public async Task ArticleVoteIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ArticleVote? articleVote = await _articleVoteRepository.GetAsync(
            predicate: av => av.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ArticleVoteShouldExistWhenSelected(articleVote);
    }
}