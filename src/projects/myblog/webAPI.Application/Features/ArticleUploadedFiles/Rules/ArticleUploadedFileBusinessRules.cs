using Application.Features.ArticleUploadedFiles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.ArticleUploadedFiles.Rules;

public class ArticleUploadedFileBusinessRules : BaseBusinessRules
{
    private readonly IArticleUploadedFileRepository _articleUploadedFileRepository;

    public ArticleUploadedFileBusinessRules(IArticleUploadedFileRepository articleUploadedFileRepository)
    {
        _articleUploadedFileRepository = articleUploadedFileRepository;
    }

    public Task ArticleUploadedFileShouldExistWhenSelected(ArticleUploadedFile? articleUploadedFile)
    {
        if (articleUploadedFile == null)
            throw new BusinessException(ArticleUploadedFilesBusinessMessages.ArticleUploadedFileNotExists);
        return Task.CompletedTask;
    }

    public async Task ArticleUploadedFileIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ArticleUploadedFile? articleUploadedFile = await _articleUploadedFileRepository.GetAsync(
            predicate: auf => auf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ArticleUploadedFileShouldExistWhenSelected(articleUploadedFile);
    }
}