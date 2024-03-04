using Application.Features.HeadArticleFeatures.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HeadArticleFeatures;

public class HeadArticleFeaturesManager : IHeadArticleFeaturesService
{
    private readonly IHeadArticleFeatureRepository _headArticleFeatureRepository;
    private readonly HeadArticleFeatureBusinessRules _headArticleFeatureBusinessRules;

    public HeadArticleFeaturesManager(IHeadArticleFeatureRepository headArticleFeatureRepository, HeadArticleFeatureBusinessRules headArticleFeatureBusinessRules)
    {
        _headArticleFeatureRepository = headArticleFeatureRepository;
        _headArticleFeatureBusinessRules = headArticleFeatureBusinessRules;
    }

    public async Task<HeadArticleFeature?> GetAsync(
        Expression<Func<HeadArticleFeature, bool>> predicate,
        Func<IQueryable<HeadArticleFeature>, IIncludableQueryable<HeadArticleFeature, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        HeadArticleFeature? headArticleFeature = await _headArticleFeatureRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return headArticleFeature;
    }

    public async Task<IPaginate<HeadArticleFeature>?> GetListAsync(
        Expression<Func<HeadArticleFeature, bool>>? predicate = null,
        Func<IQueryable<HeadArticleFeature>, IOrderedQueryable<HeadArticleFeature>>? orderBy = null,
        Func<IQueryable<HeadArticleFeature>, IIncludableQueryable<HeadArticleFeature, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<HeadArticleFeature> headArticleFeatureList = await _headArticleFeatureRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return headArticleFeatureList;
    }

    public async Task<HeadArticleFeature> AddAsync(HeadArticleFeature headArticleFeature)
    {
        HeadArticleFeature addedHeadArticleFeature = await _headArticleFeatureRepository.AddAsync(headArticleFeature);

        return addedHeadArticleFeature;
    }

    public async Task<HeadArticleFeature> UpdateAsync(HeadArticleFeature headArticleFeature)
    {
        HeadArticleFeature updatedHeadArticleFeature = await _headArticleFeatureRepository.UpdateAsync(headArticleFeature);

        return updatedHeadArticleFeature;
    }

    public async Task<HeadArticleFeature> DeleteAsync(HeadArticleFeature headArticleFeature, bool permanent = false)
    {
        HeadArticleFeature deletedHeadArticleFeature = await _headArticleFeatureRepository.DeleteAsync(headArticleFeature);

        return deletedHeadArticleFeature;
    }
}
