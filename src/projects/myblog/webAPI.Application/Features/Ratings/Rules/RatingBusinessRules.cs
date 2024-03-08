using Application.Features.Ratings.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Domain.Entities;

namespace Application.Features.Ratings.Rules;

public class RatingBusinessRules : BaseBusinessRules
{
    private readonly IRatingRepository _ratingRepository;

    public RatingBusinessRules(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public Task RatingShouldExistWhenSelected(Rating? rating)
    {
        if (rating == null)
            throw new BusinessException(RatingsBusinessMessages.RatingNotExists);
        return Task.CompletedTask;
    }

    public async Task RatingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Rating? rating = await _ratingRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RatingShouldExistWhenSelected(rating);
    }

}