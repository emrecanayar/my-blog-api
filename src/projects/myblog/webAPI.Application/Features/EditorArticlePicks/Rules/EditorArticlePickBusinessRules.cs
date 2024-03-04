using Application.Features.EditorArticlePicks.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.EditorArticlePicks.Rules;

public class EditorArticlePickBusinessRules : BaseBusinessRules
{
    private readonly IEditorArticlePickRepository _editorArticlePickRepository;

    public EditorArticlePickBusinessRules(IEditorArticlePickRepository editorArticlePickRepository)
    {
        _editorArticlePickRepository = editorArticlePickRepository;
    }

    public Task EditorArticlePickShouldExistWhenSelected(EditorArticlePick? editorArticlePick)
    {
        if (editorArticlePick == null)
            throw new BusinessException(EditorArticlePicksBusinessMessages.EditorArticlePickNotExists);
        return Task.CompletedTask;
    }

    public async Task EditorArticlePickIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        EditorArticlePick? editorArticlePick = await _editorArticlePickRepository.GetAsync(
            predicate: eap => eap.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EditorArticlePickShouldExistWhenSelected(editorArticlePick);
    }
}