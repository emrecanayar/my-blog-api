using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ArticleRepository : EfRepositoryBase<Article, Guid, BaseDbContext>, IArticleRepository
{
    public ArticleRepository(BaseDbContext context) : base(context)
    {
    }
}