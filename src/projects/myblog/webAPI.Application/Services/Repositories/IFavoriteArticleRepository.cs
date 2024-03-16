using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IFavoriteArticleRepository : IAsyncRepository<FavoriteArticle, Guid>, IRepository<FavoriteArticle, Guid>
{
}