using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ArticleVoteRepository : EfRepositoryBase<ArticleVote, Guid, BaseDbContext>, IArticleVoteRepository
{
    public ArticleVoteRepository(BaseDbContext context) : base(context)
    {
    }
}