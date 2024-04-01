using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IArticleVoteRepository : IAsyncRepository<ArticleVote, Guid>, IRepository<ArticleVote, Guid>
{
}