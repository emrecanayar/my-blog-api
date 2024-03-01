using Core.Application.Responses;

namespace Application.Features.Comments.Commands.Update;

public class UpdatedCommentResponse : IResponse
{
    public Guid Id { get; set; }
    public string AuthorName { get; set; }
    public string AuthorEmail { get; set; }
    public string AuhorWebsite { get; set; }
    public string Content { get; set; }
    public DateTime DatePosted { get; set; }
    public bool SendNewPosts { get; set; }
    public bool SendNewComments { get; set; }
    public bool RememberMe { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
}