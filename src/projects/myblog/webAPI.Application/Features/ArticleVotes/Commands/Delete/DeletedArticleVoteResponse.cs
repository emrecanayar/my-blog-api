using Core.Application.Responses;

namespace Application.Features.ArticleVotes.Commands.Delete;

public class DeletedArticleVoteResponse : IResponse
{
    public Guid Id { get; set; }
}