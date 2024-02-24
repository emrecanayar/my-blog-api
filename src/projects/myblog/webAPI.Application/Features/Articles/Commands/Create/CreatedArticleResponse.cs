using Core.Application.Responses;

namespace Application.Features.Articles.Commands.Create;

public class CreatedArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int ViewCount { get; set; }
    public int CommentCount { get; set; }
    public string SeoAuthor { get; set; } = string.Empty;
    public string SeoDescription { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}