using Core.Application.Responses;

namespace Application.Features.ArticleVotes.Commands.Update;

public class UpdatedArticleVoteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
}