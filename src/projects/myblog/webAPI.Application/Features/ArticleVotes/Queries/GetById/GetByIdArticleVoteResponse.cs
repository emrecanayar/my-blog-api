using Core.Application.Responses;

namespace Application.Features.ArticleVotes.Queries.GetById;

public class GetByIdArticleVoteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
}