using Core.Application.Responses;

namespace Application.Features.Articles.Commands.Update;

public class UpdatedArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public int ViewCount { get; set; }
    public int CommentCount { get; set; }
    public string SeoAuthor { get; set; }
    public string SeoDescription { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}