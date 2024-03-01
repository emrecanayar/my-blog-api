using Core.Application.Dtos;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string AuthorEmail { get; set; } = string.Empty;
    public string AuhorWebsite { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; }
    public bool SendNewPosts { get; set; }
    public bool SendNewComments { get; set; }
    public bool RememberMe { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
}