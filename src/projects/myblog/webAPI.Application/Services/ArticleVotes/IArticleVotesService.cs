using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ArticleVotes;

public interface IArticleVotesService
{
    Task<ArticleVote?> GetAsync(
        Expression<Func<ArticleVote, bool>> predicate,
        Func<IQueryable<ArticleVote>, IIncludableQueryable<ArticleVote, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ArticleVote>?> GetListAsync(
        Expression<Func<ArticleVote, bool>>? predicate = null,
        Func<IQueryable<ArticleVote>, IOrderedQueryable<ArticleVote>>? orderBy = null,
        Func<IQueryable<ArticleVote>, IIncludableQueryable<ArticleVote, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ArticleVote> AddAsync(ArticleVote articleVote);
    Task<ArticleVote> UpdateAsync(ArticleVote articleVote);
    Task<ArticleVote> DeleteAsync(ArticleVote articleVote, bool permanent = false);
}
