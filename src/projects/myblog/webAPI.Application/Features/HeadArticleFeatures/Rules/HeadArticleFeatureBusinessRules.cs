using Application.Features.HeadArticleFeatures.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.HeadArticleFeatures.Rules;

public class HeadArticleFeatureBusinessRules : BaseBusinessRules
{
    private readonly IHeadArticleFeatureRepository _headArticleFeatureRepository;

    public HeadArticleFeatureBusinessRules(IHeadArticleFeatureRepository headArticleFeatureRepository)
    {
        _headArticleFeatureRepository = headArticleFeatureRepository;
    }

    public Task HeadArticleFeatureShouldExistWhenSelected(HeadArticleFeature? headArticleFeature)
    {
        if (headArticleFeature == null)
            throw new BusinessException(HeadArticleFeaturesBusinessMessages.HeadArticleFeatureNotExists);
        return Task.CompletedTask;
    }

    public async Task HeadArticleFeatureIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        HeadArticleFeature? headArticleFeature = await _headArticleFeatureRepository.GetAsync(
            predicate: haf => haf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await HeadArticleFeatureShouldExistWhenSelected(headArticleFeature);
    }
}