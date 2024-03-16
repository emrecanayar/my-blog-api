using Core.Application.Responses;

namespace Application.Features.FavoriteArticles.Commands.Delete;

public class DeletedFavoriteArticleResponse : IResponse
{
    public Guid Id { get; set; }
}