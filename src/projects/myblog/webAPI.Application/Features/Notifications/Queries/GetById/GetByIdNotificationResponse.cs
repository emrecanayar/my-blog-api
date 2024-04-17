using Application.Features.Articles.Queries.GetById;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Users.Queries.GetById;
using Core.Application.Responses;

namespace Application.Features.Notifications.Queries.GetById;

public class GetByIdNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
    public Guid CommentId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public GetByIdUserResponse User { get; set; }
    public GetByIdArticleResponse Article { get; set; }
    public GetByIdCommentResponse Comment { get; set; }

    public GetByIdNotificationResponse()
    {
        User = default!;
        Article = default!;
        Comment = default!;

    }

}