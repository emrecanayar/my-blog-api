using Core.Application.Responses;

namespace Application.Features.EditorArticlePicks.Queries.GetById;

public class GetByIdEditorArticlePickResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ArticleId { get; set; }
}