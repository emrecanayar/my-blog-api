using Core.Application.Responses;

namespace Application.Features.FavoriteArticles.Commands.Create;

public class CreatedFavoriteArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
}