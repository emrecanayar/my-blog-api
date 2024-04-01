using Core.Application.Responses;
using Core.Domain.ComplexTypes.Enums;

namespace Application.Features.ArticleVotes.Commands.Create;

public class CreatedArticleVoteResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public VoteType Vote { get; set; }
}