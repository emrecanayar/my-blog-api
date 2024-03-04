using Application.Features.EditorArticlePicks.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EditorArticlePicks;

public class EditorArticlePicksManager : IEditorArticlePicksService
{
    private readonly IEditorArticlePickRepository _editorArticlePickRepository;
    private readonly EditorArticlePickBusinessRules _editorArticlePickBusinessRules;

    public EditorArticlePicksManager(IEditorArticlePickRepository editorArticlePickRepository, EditorArticlePickBusinessRules editorArticlePickBusinessRules)
    {
        _editorArticlePickRepository = editorArticlePickRepository;
        _editorArticlePickBusinessRules = editorArticlePickBusinessRules;
    }

    public async Task<EditorArticlePick?> GetAsync(
        Expression<Func<EditorArticlePick, bool>> predicate,
        Func<IQueryable<EditorArticlePick>, IIncludableQueryable<EditorArticlePick, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EditorArticlePick? editorArticlePick = await _editorArticlePickRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return editorArticlePick;
    }

    public async Task<IPaginate<EditorArticlePick>?> GetListAsync(
        Expression<Func<EditorArticlePick, bool>>? predicate = null,
        Func<IQueryable<EditorArticlePick>, IOrderedQueryable<EditorArticlePick>>? orderBy = null,
        Func<IQueryable<EditorArticlePick>, IIncludableQueryable<EditorArticlePick, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EditorArticlePick> editorArticlePickList = await _editorArticlePickRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return editorArticlePickList;
    }

    public async Task<EditorArticlePick> AddAsync(EditorArticlePick editorArticlePick)
    {
        EditorArticlePick addedEditorArticlePick = await _editorArticlePickRepository.AddAsync(editorArticlePick);

        return addedEditorArticlePick;
    }

    public async Task<EditorArticlePick> UpdateAsync(EditorArticlePick editorArticlePick)
    {
        EditorArticlePick updatedEditorArticlePick = await _editorArticlePickRepository.UpdateAsync(editorArticlePick);

        return updatedEditorArticlePick;
    }

    public async Task<EditorArticlePick> DeleteAsync(EditorArticlePick editorArticlePick, bool permanent = false)
    {
        EditorArticlePick deletedEditorArticlePick = await _editorArticlePickRepository.DeleteAsync(editorArticlePick);

        return deletedEditorArticlePick;
    }
}
