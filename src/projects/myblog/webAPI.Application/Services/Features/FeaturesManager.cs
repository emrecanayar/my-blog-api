using Application.Features.Features.Rules;
using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Features;

public class FeaturesManager : IFeaturesService
{
    private readonly IFeatureRepository _featureRepository;
    private readonly FeatureBusinessRules _featureBusinessRules;

    public FeaturesManager(IFeatureRepository featureRepository, FeatureBusinessRules featureBusinessRules)
    {
        _featureRepository = featureRepository;
        _featureBusinessRules = featureBusinessRules;
    }

    public async Task<Feature?> GetAsync(
        Expression<Func<Feature, bool>> predicate,
        Func<IQueryable<Feature>, IIncludableQueryable<Feature, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Feature? feature = await _featureRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return feature;
    }

    public async Task<IPaginate<Feature>?> GetListAsync(
        Expression<Func<Feature, bool>>? predicate = null,
        Func<IQueryable<Feature>, IOrderedQueryable<Feature>>? orderBy = null,
        Func<IQueryable<Feature>, IIncludableQueryable<Feature, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Feature> featureList = await _featureRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return featureList;
    }

    public async Task<Feature> AddAsync(Feature feature)
    {
        Feature addedFeature = await _featureRepository.AddAsync(feature);

        return addedFeature;
    }

    public async Task<Feature> UpdateAsync(Feature feature)
    {
        Feature updatedFeature = await _featureRepository.UpdateAsync(feature);

        return updatedFeature;
    }

    public async Task<Feature> DeleteAsync(Feature feature, bool permanent = false)
    {
        Feature deletedFeature = await _featureRepository.DeleteAsync(feature);

        return deletedFeature;
    }
}
