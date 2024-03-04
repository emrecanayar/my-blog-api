using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EditorArticlePicks;

public interface IEditorArticlePicksService
{
    Task<EditorArticlePick?> GetAsync(
        Expression<Func<EditorArticlePick, bool>> predicate,
        Func<IQueryable<EditorArticlePick>, IIncludableQueryable<EditorArticlePick, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EditorArticlePick>?> GetListAsync(
        Expression<Func<EditorArticlePick, bool>>? predicate = null,
        Func<IQueryable<EditorArticlePick>, IOrderedQueryable<EditorArticlePick>>? orderBy = null,
        Func<IQueryable<EditorArticlePick>, IIncludableQueryable<EditorArticlePick, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EditorArticlePick> AddAsync(EditorArticlePick editorArticlePick);
    Task<EditorArticlePick> UpdateAsync(EditorArticlePick editorArticlePick);
    Task<EditorArticlePick> DeleteAsync(EditorArticlePick editorArticlePick, bool permanent = false);
}
