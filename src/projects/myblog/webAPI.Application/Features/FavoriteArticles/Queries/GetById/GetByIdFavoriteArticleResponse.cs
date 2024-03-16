using Application.Features.Articles.Queries.GetById;
using Application.Features.Users.Queries.GetById;
using Core.Application.Responses;

namespace Application.Features.FavoriteArticles.Queries.GetById;

public class GetByIdFavoriteArticleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public GetByIdUserResponse User { get; set; }
    public Guid ArticleId { get; set; }
    public GetByIdArticleResponse Article { get; set; }

    public GetByIdFavoriteArticleResponse()
    {
        User = default!;
        Article = default!;
    }
}