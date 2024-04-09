using Core.Application.Dtos;
using Core.Domain.ComplexTypes.Enums;

namespace Application.Features.ArticleVotes.Queries.GetList;

public class GetListArticleVoteListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public VoteType Vote { get; set; }
}