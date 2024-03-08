using Application.Features.Ratings.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ratings;

public class RatingsManager : IRatingsService
{
    private readonly IRatingRepository _ratingRepository;
    private readonly RatingBusinessRules _ratingBusinessRules;

    public RatingsManager(IRatingRepository ratingRepository, RatingBusinessRules ratingBusinessRules)
    {
        _ratingRepository = ratingRepository;
        _ratingBusinessRules = ratingBusinessRules;
    }

    public async Task<Rating?> GetAsync(
        Expression<Func<Rating, bool>> predicate,
        Func<IQueryable<Rating>, IIncludableQueryable<Rating, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Rating? rating = await _ratingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rating;
    }

    public async Task<IPaginate<Rating>?> GetListAsync(
        Expression<Func<Rating, bool>>? predicate = null,
        Func<IQueryable<Rating>, IOrderedQueryable<Rating>>? orderBy = null,
        Func<IQueryable<Rating>, IIncludableQueryable<Rating, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Rating> ratingList = await _ratingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ratingList;
    }

    public async Task<Rating> AddAsync(Rating rating)
    {
        Rating addedRating = await _ratingRepository.AddAsync(rating);

        return addedRating;
    }

    public async Task<Rating> UpdateAsync(Rating rating)
    {
        Rating updatedRating = await _ratingRepository.UpdateAsync(rating);

        return updatedRating;
    }

    public async Task<Rating> DeleteAsync(Rating rating, bool permanent = false)
    {
        Rating deletedRating = await _ratingRepository.DeleteAsync(rating);

        return deletedRating;
    }
}
