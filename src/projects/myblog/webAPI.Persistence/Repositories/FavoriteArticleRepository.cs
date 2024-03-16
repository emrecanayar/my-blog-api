using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class FavoriteArticleRepository : EfRepositoryBase<FavoriteArticle, Guid, BaseDbContext>, IFavoriteArticleRepository
{
    public FavoriteArticleRepository(BaseDbContext context) : base(context)
    {
    }
}