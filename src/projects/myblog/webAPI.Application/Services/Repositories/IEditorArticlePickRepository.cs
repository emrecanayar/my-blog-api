using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEditorArticlePickRepository : IAsyncRepository<EditorArticlePick, Guid>, IRepository<EditorArticlePick, Guid>
{
}