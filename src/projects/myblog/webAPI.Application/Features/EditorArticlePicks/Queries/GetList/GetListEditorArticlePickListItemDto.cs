using Application.Features.Articles.Queries.GetById;
using Application.Features.Users.Queries.GetById;
using Core.Application.Dtos;

namespace Application.Features.EditorArticlePicks.Queries.GetList;

public class GetListEditorArticlePickListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public GetByIdUserResponse User { get; set; }
    public Guid ArticleId { get; set; }
    public GetByIdArticleResponse Article { get; set; }

    public GetListEditorArticlePickListItemDto()
    {
        User = default!;
        Article = default!;
    }
}