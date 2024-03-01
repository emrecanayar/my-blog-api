using Application.Features.Features.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Features.Rules;

public class FeatureBusinessRules : BaseBusinessRules
{
    private readonly IFeatureRepository _featureRepository;

    public FeatureBusinessRules(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public Task FeatureShouldExistWhenSelected(Feature? feature)
    {
        if (feature == null)
            throw new BusinessException(FeaturesBusinessMessages.FeatureNotExists);
        return Task.CompletedTask;
    }

    public async Task FeatureIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Feature? feature = await _featureRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FeatureShouldExistWhenSelected(feature);
    }
}