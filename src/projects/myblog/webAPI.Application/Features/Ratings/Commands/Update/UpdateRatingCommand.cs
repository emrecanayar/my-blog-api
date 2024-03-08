using Application.Features.Ratings.Constants;
using Application.Features.Ratings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Ratings.Commands.Update;

public class UpdateRatingCommand : IRequest<CustomResponseDto<UpdatedRatingResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }

    public string[] Roles => [RatingsOperationClaims.Update];

    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, CustomResponseDto<UpdatedRatingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly RatingBusinessRules _ratingBusinessRules;

        public UpdateRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository,
                                         RatingBusinessRules ratingBusinessRules)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _ratingBusinessRules = ratingBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedRatingResponse>> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            Rating? rating = await _ratingRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _ratingBusinessRules.RatingShouldExistWhenSelected(rating);
            rating = _mapper.Map(request, rating);
            await _ratingRepository.UpdateAsync(rating!);
            UpdatedRatingResponse response = _mapper.Map<UpdatedRatingResponse>(rating);
            return CustomResponseDto<UpdatedRatingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}