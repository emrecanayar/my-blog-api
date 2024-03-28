using Application.Features.Auth.Commands.Login;

namespace webAPI.Application.Features.FavoriteArticles.Commands.DeleteByArticleId
{
    public class DeleteFavoriteArticleByArticleIdResponse : IResponse
    {
        public Guid Id { get; set; }
    }
}
