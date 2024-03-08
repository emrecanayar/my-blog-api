using Application.Features.Ratings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Ratings.Commands.Create;

public class CreateRatingCommand : IRequest<CustomResponseDto<CreatedRatingResponse>>, ISecuredRequest
{
    public int Score { get; set; }
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }

    public string[] Roles => [RatingsOperationClaims.Admin, RatingsOperationClaims.Write];

    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CustomResponseDto<CreatedRatingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;

        public CreateRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }

        public async Task<CustomResponseDto<CreatedRatingResponse>> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            Rating rating = _mapper.Map<Rating>(request);
            await _ratingRepository.AddAsync(rating);
            CreatedRatingResponse response = _mapper.Map<CreatedRatingResponse>(rating);
            return CustomResponseDto<CreatedRatingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}