using Core.Application.Responses;

namespace Application.Features.FavoriteArticles.Commands.Update;

public class UpdatedFavoriteArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
}