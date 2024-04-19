using Application.Features.Likes.Constants;
using Application.Features.Likes.Rules;
using Application.Features.Notifications.Commands.Create;
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

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CustomResponseDto<CreatedLikeResponse>>, ISecuredRequest
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public Guid CommentId { get; set; }
    public bool IsLiked { get; set; }
    public string UserFullName { get; set; } = string.Empty;
    public Guid ArticleId { get; set; }

    public string[] Roles => [LikesOperationClaims.Admin, LikesOperationClaims.Create];

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CustomResponseDto<CreatedLikeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly INotificationsService _notificationService;
        private readonly LikeBusinessRules _likeBusinessRules;


        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository, INotificationsService notificationService, LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _notificationService = notificationService;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedLikeResponse>> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = _mapper.Map<Like>(request);
            Like addedLike = await _likeRepository.AddAsync(like);
            await _likeBusinessRules.LikeShouldExistWhenSelected(addedLike);
            await _notificationService.CreateNotificationAsync(new CreateNotificationCommand { Content = $"{request.UserFullName}, yorumunuzu beðendi.", Type = NotificationType.CommentLike, CommentId = request.CommentId, UserId = request.UserId, ArticleId = request.ArticleId });
            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(like);
            return CustomResponseDto<CreatedLikeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}