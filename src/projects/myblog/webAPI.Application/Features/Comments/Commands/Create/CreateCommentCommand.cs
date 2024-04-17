using Application.Features.Comments.Rules;
using Application.Features.Notifications.Commands.Create;
using Application.Services.Notifications;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.ComplexTypes.Enums;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommand : IRequest<CustomResponseDto<CreatedCommentResponse>>
{
    public string AuthorName { get; set; } = string.Empty;
    public string AuthorEmail { get; set; } = string.Empty;
    public string AuhorWebsite { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime DatePosted { get; set; } = DateTime.Now;
    public bool SendNewPosts { get; set; }
    public bool SendNewComments { get; set; }
    public bool RememberMe { get; set; }
    public Guid ArticleId { get; set; }
    public Guid? UserId { get; set; }
    public Guid UserIdForArticle { get; set; }
    public string ArticleTitleForComment { get; set; } = string.Empty;

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CustomResponseDto<CreatedCommentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly INotificationsService _notificationsService;
        private readonly CommentBusinessRules _commentBusinessRules;


        public CreateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository, INotificationsService notificationsService, CommentBusinessRules commentBusinessRules)

        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _notificationsService = notificationsService;
            _commentBusinessRules = commentBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedCommentResponse>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            Comment addedComment = await _commentRepository.AddAsync(comment);
            await _commentBusinessRules.CommentShouldExistWhenSelected(addedComment);
            await _notificationsService.CreateNotificationAsync(new CreateNotificationCommand { Content = $"{request.AuthorName} kiþisi {request.ArticleTitleForComment} yazýnýza yorum yaptý.", Type = NotificationType.Comment, UserId = request.UserIdForArticle, ArticleId = request.ArticleId, CommentId = addedComment.Id });
            CreatedCommentResponse response = _mapper.Map<CreatedCommentResponse>(addedComment);
            return CustomResponseDto<CreatedCommentResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}