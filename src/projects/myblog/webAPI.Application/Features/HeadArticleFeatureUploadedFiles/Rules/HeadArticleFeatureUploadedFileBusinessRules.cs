using Application.Features.HeadArticleFeatureUploadedFiles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.HeadArticleFeatureUploadedFiles.Rules;

public class HeadArticleFeatureUploadedFileBusinessRules : BaseBusinessRules
{
    private readonly IHeadArticleFeatureUploadedFileRepository _headArticleFeatureUploadedFileRepository;

    public HeadArticleFeatureUploadedFileBusinessRules(IHeadArticleFeatureUploadedFileRepository headArticleFeatureUploadedFileRepository)
    {
        _headArticleFeatureUploadedFileRepository = headArticleFeatureUploadedFileRepository;
    }

    public Task HeadArticleFeatureUploadedFileShouldExistWhenSelected(HeadArticleFeatureUploadedFile? headArticleFeatureUploadedFile)
    {
        if (headArticleFeatureUploadedFile == null)
            throw new BusinessException(HeadArticleFeatureUploadedFilesBusinessMessages.HeadArticleFeatureUploadedFileNotExists);
        return Task.CompletedTask;
    }

    public async Task HeadArticleFeatureUploadedFileIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        HeadArticleFeatureUploadedFile? headArticleFeatureUploadedFile = await _headArticleFeatureUploadedFileRepository.GetAsync(
            predicate: hafuf => hafuf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await HeadArticleFeatureUploadedFileShouldExistWhenSelected(headArticleFeatureUploadedFile);
    }
}