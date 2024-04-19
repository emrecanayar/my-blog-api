using Application.Features.Notifications.Commands.Create;
using Application.Features.Ratings.Constants;
using Application.Features.Ratings.Rules;
using Application.Services.Notifications;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
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
    public string UserFullName { get; set; } = string.Empty;
    public string ArticleTitleForRating { get; set; } = string.Empty;

    public string[] Roles => [RatingsOperationClaims.Admin, RatingsOperationClaims.Write];

    public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, CustomResponseDto<CreatedRatingResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        private readonly INotificationsService _notificationsService;
        private readonly RatingBusinessRules _ratingBusinessRules;

        public CreateRatingCommandHandler(IMapper mapper, IRatingRepository ratingRepository, INotificationsService notificationsService, RatingBusinessRules ratingBusinessRules)
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
            _notificationsService = notificationsService;
            _ratingBusinessRules = ratingBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedRatingResponse>> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            Rating rating = _mapper.Map<Rating>(request);
            Rating addedRating = await _ratingRepository.AddAsync(rating);
            await _ratingBusinessRules.RatingShouldExistWhenSelected(addedRating);
            await _notificationsService.CreateNotificationAsync(new CreateNotificationCommand { Type = NotificationType.PostLike, ArticleId = request.ArticleId, CommentId = null, UserId = request.UserId, Content = $"{request.UserFullName}, {request.ArticleTitleForRating} adlý yazýnýzý deðerlendirdi." });
            CreatedRatingResponse response = _mapper.Map<CreatedRatingResponse>(rating);
            return CustomResponseDto<CreatedRatingResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}