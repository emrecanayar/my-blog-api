using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class EditorArticlePickRepository : EfRepositoryBase<EditorArticlePick, Guid, BaseDbContext>, IEditorArticlePickRepository
{
    public EditorArticlePickRepository(BaseDbContext context) : base(context)
    {
    }
}