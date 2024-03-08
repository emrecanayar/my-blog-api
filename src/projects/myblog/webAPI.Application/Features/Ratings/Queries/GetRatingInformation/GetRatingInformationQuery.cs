using Application.Features.Ratings.Constants;
using Application.Features.Ratings.Rules;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace webAPI.Application.Features.Ratings.Queries.GetRatingInformation
{
    public class GetRatingInformationQuery : IRequest<CustomResponseDto<GetRatingInformationResponse>>, ISecuredRequest
    {
        public Guid ArticleId { get; set; }
        [JsonIgnore]
        public Guid UserId { get; set; }

        public string[] Roles => [RatingsOperationClaims.Read];

        public class GetRatingInformationQueryHandler : IRequestHandler<GetRatingInformationQuery, CustomResponseDto<GetRatingInformationResponse>>
        {
            private readonly IRatingRepository _ratingRepository;
            private readonly RatingBusinessRules _ratingBusinessRules;

            public GetRatingInformationQueryHandler(IRatingRepository ratingRepository, RatingBusinessRules ratingBusinessRules)
            {
                _ratingRepository = ratingRepository;
                _ratingBusinessRules = ratingBusinessRules;
            }

            public async Task<CustomResponseDto<GetRatingInformationResponse>> Handle(GetRatingInformationQuery request, CancellationToken cancellationToken)
            {
                Rating? rating = await _ratingRepository.GetAsync(x => x.UserId == request.UserId && x.ArticleId == request.ArticleId, cancellationToken: cancellationToken);

                await _ratingBusinessRules.RatingShouldExistWhenSelected(rating);

                return CustomResponseDto<GetRatingInformationResponse>.Success((int)HttpStatusCode.OK, new GetRatingInformationResponse { Id = rating.Id, IsThere = true, Score = rating.Score }, true);
            }
        }
    }
}
