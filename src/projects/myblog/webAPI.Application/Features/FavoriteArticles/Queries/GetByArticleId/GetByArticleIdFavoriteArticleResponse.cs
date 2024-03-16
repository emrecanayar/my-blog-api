using Application.Features.Auth.Commands.Login;

namespace webAPI.Application.Features.FavoriteArticles.Queries.GetByArticleId
{
    public class GetByArticleIdFavoriteArticleResponse : IResponse
    {
        public Guid Id { get; set; }
        public bool IsThere { get; set; }
    }
}
